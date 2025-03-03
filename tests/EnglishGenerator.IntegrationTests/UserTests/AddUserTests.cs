using System.Net;
using EnglishGenerator.Presentation.WebApi.ApiModels.User;
using EnglishGenerator.Presentation.WebApi.Endpoints;
using FastEndpoints;

namespace EnglishGenerator.IntegrationTests.UserTests;

public class AddUserTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task CiCdTest()
    {
        // Arrange
        var createClientRequestDto = new CreateUserRequest
        {
            Username = "test",
            EmailAddress = "test@test.com"
        };

        // Act
        var response = await Client.POSTAsync<Users, CreateUserRequest>(createClientRequestDto);

        // Assert
        Assert.Equivalent(HttpStatusCode.Conflict, response.StatusCode);
    }
}