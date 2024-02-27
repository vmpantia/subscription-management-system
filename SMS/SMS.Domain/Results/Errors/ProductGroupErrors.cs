using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class ProductGroupErrors
    {
        public static Error NotFound(object id) => new(ErrorCode.NotFound, "Product Group", $"Product Group with an Id {id} is NOT found on the database.");
    }
}
