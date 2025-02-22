using EnglishGenerator.Core.DomainModels;
using EnglishGenerator.Core.Dtos;
using EnglishGenerator.Core.Enums;
using EnglishGenerator.Core.Interfaces.Repositories;
using EnglishGenerator.Core.ResultTypes;

namespace EnglishGenerator.Core.Services;

public interface IUserService
{
    Task<Result<User, UserCreationError>> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
}

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Result<User, UserCreationError>> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetUserAsync(createUserDto.EmailAddress, cancellationToken);

        if (existingUser != null)
        {
            return Result<User, UserCreationError>.Fail(UserCreationError.UserWithThisEmailAlreadyExists);
        }

        var newUser = new User
        {
            UserId = Guid.NewGuid(),
            EmailAddress = createUserDto.EmailAddress,
            Username = createUserDto.Username
        };

        var created = await userRepository.AddUserAsync(newUser, cancellationToken);

        if (!created)
        {
            return Result<User, UserCreationError>.Fail(UserCreationError.UnknownError);
        }

        return Result<User, UserCreationError>.Ok(newUser);
    }
}