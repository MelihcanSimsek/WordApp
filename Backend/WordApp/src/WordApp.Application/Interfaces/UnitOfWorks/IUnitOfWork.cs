using WordApp.Application.Interfaces.Repositories;
using WordApp.Domain.Abstractions;

namespace WordApp.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase, new();
    IReadRepository<T> GetReadRepository<T>() where T : EntityBase, new();
    Task<int> SaveAsync();
    int Save();
}
