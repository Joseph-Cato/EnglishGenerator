using EnglishGenerator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishGenerator.Core;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigureCore(this IServiceCollection services)
    {
        return services.AddScoped<IUserService, UserService>();
    }
}