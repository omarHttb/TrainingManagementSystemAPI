namespace TrainingManagementSystemAPI.ApiResponse
{
    public class ApiResponsel
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public object? Errors { get; set; } // Can hold FluentValidation errors or stack traces    }
    }

}
