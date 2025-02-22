namespace EnglishGenerator.Presentation.WebApi.ApiModels.User;

public record CreateUserRequest : AbstractRequest
{
    public const int MaxUserNameLength = 50;
    public const int MinUserNameLength = 3;

    public required string Username { get; init; }
    public required string EmailAddress { get; init; }
}