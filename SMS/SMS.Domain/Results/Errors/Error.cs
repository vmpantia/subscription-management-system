using SMS.Domain.Models.Enums;

namespace SMS.Domain.Results.Errors
{
    public sealed record Error(ErrorCode Code, string Type, string Description) { }
}
