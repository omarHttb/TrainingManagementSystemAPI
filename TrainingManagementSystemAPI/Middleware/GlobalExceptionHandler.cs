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

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            var code = "INTERNAL_SERVER_ERROR";
            var title = "Server Error";
            var detail = exception.Message;
            object? details = null;

            switch (exception)
            {
                case ArgumentException:
                    statusCode = StatusCodes.Status400BadRequest;
                    code = "INVALID_INPUT";
                    title = "Bad Request";
                    break;

                case KeyNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    code = "NOT_FOUND";
                    title = "Resource Not Found";
                    break;

                case FluentValidation.ValidationException vex:
                    statusCode = StatusCodes.Status400BadRequest;
                    code = "VALIDATION_FAILED";
                    title = "Validation Error";
                    detail = "One or more validation failures occurred.";
                    details = vex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage });
                    break;

                case DbUpdateException dbEx when IsForeignKeyViolation(dbEx, out var field):
                    statusCode = StatusCodes.Status400BadRequest;
                    code = "FOREIGN_KEY_VIOLATION";
                    title = "Dependency Error";
                    detail = $"The provided {field} does not exist.";
                    details = new[] { new { field, message = $"Invalid {field}" } };
                    break;
            }

            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            await WriteResponse(context, statusCode, title, detail, code, details);
        }

        private static async Task WriteResponse(
            HttpContext context,
            int statusCode,
            string title,
            string detail,
            string code,
            object? details)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                statusCode,
                title,
                detail,
                instance = context.Request.Path.Value,
                code,
                details
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }

        private static bool IsForeignKeyViolation(DbUpdateException ex, out string fieldName)
        {
            fieldName = "Id";
            if (ex.InnerException is not SqlException sqlEx || sqlEx.Number != 547) return false;
            var match = Regex.Match(sqlEx.Message, @"FK_[A-Za-z0-9]+_([A-Za-z0-9]+)");
            if (match.Success) fieldName = match.Groups[1].Value;
            return true;
        }
    }
}
