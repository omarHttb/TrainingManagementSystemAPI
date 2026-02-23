using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace TrainingManagementSystemAPI.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            RequestDelegate next,
            ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await WriteResponse(context, ex.Message);
            }
            catch (FluentValidation.ValidationException ex)
            {

                _logger.LogWarning(ex, ex.Message);

                var errorDetails = ex.Errors
                .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await WriteResponse(context, errorDetails);
            }

            // EXTREMLY IMPORTANT NOTE
            // THE CATCH BELOW ONLY WORKS WELL WHEN THE FOREGIN KEY IS NAMED LIKE THIS
            // FK_ExampleTable1_ExampleTable2Id
            catch (DbUpdateException ex) when (IsForeignKeyViolation(ex, out var field))
            {
                _logger.LogWarning(ex, "Foreign key violation on {Field}", field);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await WriteResponse(context, new
                {
                    Field = field,
                    Message = $"Invalid {field}"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await WriteResponse(context, ex.Message);
            }
        }
        private static bool IsForeignKeyViolation(
            DbUpdateException ex,
            out string fieldName)
        {
            fieldName = "Id";

            if (ex.InnerException is not SqlException sqlEx || sqlEx.Number != 547)
                return false;

            var match = Regex.Match(
                sqlEx.Message,
                @"FK_[A-Za-z0-9]+_([A-Za-z0-9]+)");

            if (!match.Success)
                return true;

            fieldName = match.Groups[1].Value;
            return true;
        }

        private static async Task WriteResponse(HttpContext context, object errorData)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = errorData
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }


    }
}
