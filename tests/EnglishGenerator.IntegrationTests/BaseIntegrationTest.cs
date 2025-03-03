using EnglishGenerator.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishGenerator.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly EnglishGeneratorDbContext DbContext;
    protected readonly HttpClient Client;

    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();

        DbContext = _scope.ServiceProvider.GetRequiredService<EnglishGeneratorDbContext>();

        Client = factory.CreateClient();
    }

    public void Dispose()
    {
        _scope?.Dispose();
        DbContext?.Dispose();
    }
}