using WordApp.Application.Interfaces.Repositories;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Infrastructure.Context;
using WordApp.Infrastructure.Repositories;

namespace WordApp.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
    public int Save() => dbContext.SaveChanges();
    public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
}
