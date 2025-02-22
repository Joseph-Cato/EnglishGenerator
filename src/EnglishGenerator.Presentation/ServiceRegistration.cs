using EnglishGenerator.Core.Dtos;
using EnglishGenerator.Presentation.Mappers;
using EnglishGenerator.Presentation.Validators;
using EnglishGenerator.Presentation.WebApi.ApiModels.User;
using FluentValidation;

namespace EnglishGenerator.Presentation;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigurePresentation(this IServiceCollection services)
    {
        return services
            .AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>()
            .AddSingleton<AbstractRequestDtoMapper<CreateUserRequest, CreateUserDto>, CreateUserRequestDtoMapper>();
    }
}