using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public class SubscriptionErrors
    {
        public static Error NotFound(object id) => new(ErrorCode.NotFound, "Subscription", $"Subscription with an Id {id} is NOT found on the database.");
        public static Error NullValue => new(ErrorCode.NullValue, "Subscription", "Subscription cannnot be NULL.");
    }
}
