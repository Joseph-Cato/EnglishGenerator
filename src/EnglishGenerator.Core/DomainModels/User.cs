namespace EnglishGenerator.Core.DomainModels;

public class User
{
    public required Guid UserId { get; init; }
    public required string Username { get; set; }
    public required string EmailAddress { get; set; }
}