namespace EnglishGenerator.Core.Interfaces;

public interface IUnitOfWork
{
    Task SavesChangesAsync();
}