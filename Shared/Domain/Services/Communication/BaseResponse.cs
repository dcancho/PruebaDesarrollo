namespace PruebaDesarrollo.Shared.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T? Data { get; protected set; }

        protected BaseResponse(string message, bool success = false)
        {
            Success = success;
            Message = message;
            Data = default;
        }
        protected BaseResponse(T data)
        {
            Success = true;
            Message = string.Empty;
            Data = data;
        }
    }
}
