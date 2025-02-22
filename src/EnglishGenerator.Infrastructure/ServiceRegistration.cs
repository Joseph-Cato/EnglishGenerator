using EnglishGenerator.Core.Interfaces.Repositories;
using EnglishGenerator.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishGenerator.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }
}