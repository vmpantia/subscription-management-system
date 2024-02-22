using SMS.Domain.Results.Errors;

namespace SMS.Domain.Results
{
    public class Result<TData>
    {
        private Result(bool isSuccess, Error? error, TData? data)
        {
            if (isSuccess && error is not null ||
                !isSuccess && error is null)
                throw new ArgumentException("Invalid error", nameof(error));

            IsSuccess = isSuccess;
            Error = error;
            Data = data;
        }
        
        public bool IsSuccess { get; }
        public Error? Error { get; }
        public TData? Data { get; }
        public static Result<TData> Success(TData data) => new(true, null, data);
        public static Result<TData> Failure(Error error) => new(false, error, default);
    }
}
