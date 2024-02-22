using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class ProductErrors
    {
        public static Error NotFound(Guid id) => new(ErrorCode.NotFound, "Product", $"Product with an Id {id} is NOT found on the database.");
        public static Error NULL => new(ErrorCode.NullValue,"Product", "Product cannnot be NULL.");
    }
}
