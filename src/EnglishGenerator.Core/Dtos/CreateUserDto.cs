namespace EnglishGenerator.Core.Dtos;

public record CreateUserDto : AbstractDto
{
    public required string Username { get; set; }
    public required string EmailAddress { get; set; }
}