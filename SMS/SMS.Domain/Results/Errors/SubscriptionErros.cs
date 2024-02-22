namespace SMS.Domain.Results.Errors
{
    public class SubscriptionErros
    {
        public static Error NotFound(Guid id) => new("Subscription.NotFound", $"Subscription with an Id {id} is NOT found on the database.");
        public static Error NULL => new("Subscriptions.NULL", "Subscriptions cannnot be NULL.");
    }
}
