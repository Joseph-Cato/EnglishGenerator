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
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        _scope.Dispose();
        DbContext.Dispose();
    }
}