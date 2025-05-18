using WordApp.Domain.Abstractions;

namespace WordApp.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : EntityBase,new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task<T> UpdateAsync(T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(ICollection<T> entities);
}
