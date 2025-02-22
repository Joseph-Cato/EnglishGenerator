using EnglishGenerator.Core.Dtos;
using EnglishGenerator.Presentation.WebApi.ApiModels.User;

namespace EnglishGenerator.Presentation.Mappers;

public class CreateUserRequestDtoMapper : AbstractRequestDtoMapper<CreateUserRequest, CreateUserDto>
{
    public override CreateUserDto MapToDto(CreateUserRequest request)
    {
        return new CreateUserDto
        {
            Username = request.Username,
            EmailAddress = request.EmailAddress
        };
    }
}