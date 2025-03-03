using EnglishGenerator.Core.Enums;

namespace EnglishGenerator.Presentation.WebApi.ApiModels.User;

public record CreateUserResponse
{
    public required Guid? UserId { get; set; }

    public required List<UserCreationError>? Errors { get; set; }
}