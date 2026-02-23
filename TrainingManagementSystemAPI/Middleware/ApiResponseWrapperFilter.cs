using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TrainingManagementSystemAPI.Middleware
{
    public class ApiResponseWrapperFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(
      ResultExecutingContext context,
      ResultExecutionDelegate next)
        {
            // Only wrap ObjectResult (normal JSON responses)
            if (context.Result is ObjectResult objectResult)
            {
                // Avoid double wrapping
                if (objectResult.Value is not null &&
                    objectResult.Value.GetType().IsGenericType &&
                    objectResult.Value.GetType().GetGenericTypeDefinition() == typeof(ApiResponse<>))
                {
                    await next();
                    return;
                }

                var wrappedResponse = new ApiResponse<object>(objectResult.Value);

                context.Result = new ObjectResult(wrappedResponse)
                {
                    StatusCode = objectResult.StatusCode ?? 200
                };
            }

            await next();
        }

    }
}
