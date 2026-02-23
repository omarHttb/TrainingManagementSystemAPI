namespace TrainingManagementSystemAPI.Middleware
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(T data, string message = "Operation completed successfully")
        {
            Success = true;
            Message = message;
            Data = data;
        }

    }
}
