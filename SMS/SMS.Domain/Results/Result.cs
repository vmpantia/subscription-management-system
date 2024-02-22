using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results
{
    public class Result<TData>
    {
        private Result(Success<TData> success)
        {
            IsSuccess = true;
            Success = success;
            Error = null;
        }

        private Result(Error error)
        {
            IsSuccess = false;
            Success = null;
            Error = error;
        }
        
        public bool IsSuccess { get; }
        public Success<TData>? Success { get; }
        public Error? Error { get; }

        public static Result<TData> Done(TData? data, string? message = null) => new(new Success<TData>(data, message));
        public static Result<TData> Failure(Error error) => new(error);
    }

    public sealed record Success<TData>(TData? Data, string? Message) { }
    public sealed record Error(ErrorCode Code, string Type, string Description) { }
}
