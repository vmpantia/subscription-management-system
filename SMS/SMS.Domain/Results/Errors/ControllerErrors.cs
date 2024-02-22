using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class ControllerErrors
    {
        public static Error Unexpected(Exception exception) => new(ErrorCode.Unexpected, nameof(exception), exception.ToString());
    }
}
