using System.Net;
using EnglishGenerator.Core.Dtos;
using EnglishGenerator.Core.Services;
using EnglishGenerator.Presentation.Mappers;
using EnglishGenerator.Presentation.WebApi.ApiModels.User;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace EnglishGenerator.Presentation.WebApi.Endpoints;

[HttpPost("users"), AllowAnonymous]
public class Users(
    AbstractRequestDtoMapper<CreateUserRequest, CreateUserDto> createUserRequestDtoMapper,
    IUserService userService)
    : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var createUserDto = createUserRequestDtoMapper.MapToDto(request);

        var result = await userService.CreateUserAsync(createUserDto, ct);

        await result.Match(
            success: x => SendAsync(new CreateUserResponse { UserId = x.UserId, Errors = null }, (int) HttpStatusCode.Created, ct),
            failure: x => SendAsync(new CreateUserResponse { UserId = null, Errors = [x] }, (int) HttpStatusCode.Conflict, ct)
        );
    }
}