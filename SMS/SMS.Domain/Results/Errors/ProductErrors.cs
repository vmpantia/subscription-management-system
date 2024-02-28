using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class ProductErrors
    {
        public static Error NotFound(object id) => new(ErrorCode.NotFound, "Product", $"Product with an Id {id} is NOT found on the database.");
        public static Error NullValue => new(ErrorCode.NullValue, "Product", "Product(s) cannnot be NULL.");
        public static Error AlreadyDeleted => new(ErrorCode.AlreadyDeleted, "Product", "Product is already deleted on the database.");
    }
}
