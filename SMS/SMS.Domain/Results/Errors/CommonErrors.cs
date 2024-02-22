using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class CommonErrors
    {
        public static Error NotFound(string typeName, object id) => new(ErrorCode.NotFound, typeName, $"{typeName} with an Id {id} is NOT found on the database.");
        public static Error NullValue(string typeName) => new(ErrorCode.NullValue, typeName, $"{typeName} cannnot be NULL.");
    }
}
