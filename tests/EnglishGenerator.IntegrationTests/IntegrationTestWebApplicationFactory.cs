using EnglishGenerator.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace EnglishGenerator.IntegrationTests;

// ReSharper disable once ClassNeverInstantiated.Global
public class IntegrationTestWebApplicationFactory :
    WebApplicationFactory<Program>,
    IAsyncLifetime
{
    protected readonly PostgreSqlContainer PostgreSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:17-alpine")
        .Build();

    public Task InitializeAsync() => PostgreSqlContainer.StartAsync();

    public new Task DisposeAsync() => PostgreSqlContainer.DisposeAsync().AsTask();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptorType = typeof(DbContextOptions<EnglishGeneratorDbContext>);

            var descriptor = services.SingleOrDefault(d => d.ServiceType == descriptorType);

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<EnglishGeneratorDbContext>(options =>
                options.UseSqlServer(PostgreSqlContainer.GetConnectionString()));
        });
    }
}