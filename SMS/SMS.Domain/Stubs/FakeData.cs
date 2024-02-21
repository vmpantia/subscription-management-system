using Bogus;
using Bogus.Extensions.UnitedStates;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;

namespace SMS.Domain.Stubs
{
    public class FakeData
    {
        public static Faker<Subscription> FakerSubscription()
        {
            return new Faker<Subscription>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Description, faker => faker.Company.Ein())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<SubscriptionStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());
        }
    }
}
