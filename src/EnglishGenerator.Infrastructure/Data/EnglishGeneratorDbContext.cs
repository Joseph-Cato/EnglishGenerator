using EnglishGenerator.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishGenerator.Infrastructure.Data;

public class EnglishGeneratorDbContext(DbContextOptions<EnglishGeneratorDbContext> options) : DbContext(options), IUnitOfWork
{
    public async Task SavesChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}