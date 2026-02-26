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
            if (context.Result is ObjectResult objectResult)
            {
                
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
