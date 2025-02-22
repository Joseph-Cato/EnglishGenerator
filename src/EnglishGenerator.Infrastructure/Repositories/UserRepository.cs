using EnglishGenerator.Core.DomainModels;
using EnglishGenerator.Core.Interfaces.Repositories;

namespace EnglishGenerator.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User?> GetUserAsync(string email, CancellationToken cancellationToken)
    {
        var test = new User
        {
            UserId = Guid.NewGuid(),
            Username = "test-user",
            EmailAddress = email,
        };

        return Task.FromResult(test)!;
    }

    public Task<bool> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}