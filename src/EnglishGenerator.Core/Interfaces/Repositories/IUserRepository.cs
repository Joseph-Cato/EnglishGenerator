using EnglishGenerator.Core.DomainModels;

namespace EnglishGenerator.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserAsync(string email, CancellationToken cancellationToken);

    Task<bool> AddUserAsync(User user, CancellationToken cancellationToken);
}
