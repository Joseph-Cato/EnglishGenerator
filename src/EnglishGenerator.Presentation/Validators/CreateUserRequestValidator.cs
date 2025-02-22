using FluentValidation;
using EnglishGenerator.Presentation.WebApi.ApiModels.User;

namespace EnglishGenerator.Presentation.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(CreateUserRequest.MaxUserNameLength)
            .MinimumLength(CreateUserRequest.MinUserNameLength)
            .WithMessage($"Username must be between {CreateUserRequest.MinUserNameLength} and {CreateUserRequest.MaxUserNameLength} characters");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .WithMessage("Email address is required")
            .EmailAddress()
            .WithMessage("Must be a valid email address");
    }
}