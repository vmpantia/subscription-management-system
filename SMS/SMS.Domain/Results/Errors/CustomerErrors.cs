using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class CustomerErrors
    {
        public static Error NotFound(object id) => new(ErrorCode.NotFound, "Customer", $"Customer with an Id {id} is NOT found on the database.");
    }
}
