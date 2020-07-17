namespace API.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; }

        public string Message { get; }

        public T Resource { get; }

        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}