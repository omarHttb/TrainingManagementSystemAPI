using FluentValidation;

namespace TrainingManagementSystemAPI.ApiResponse
{
    public static class ResponseFactory
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(T data, string message = "Request completed successfully")
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                Errors = null
            };
        }
        public static ApiResponse<object> CreateErrorResponse(Exception exception)
        {
            var response = new ApiResponse<object>
            {
                IsSuccess = false,
                Data = null
            };

            if (exception is ValidationException validationException)
            {
                response.Message = "Validation failed";
                response.Errors = validationException.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray()
                    );
            }
            else
            {
                // Handle standard/unhandled exceptions
                response.Message = "An unexpected error occurred.";
                // Note: In production, you might want to hide the actual exception message
                response.Errors = new { Details = exception.Message };
            }

            return response;
        }
    }
}
