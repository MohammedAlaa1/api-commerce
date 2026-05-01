using System.Linq.Expressions;

namespace ECommerce.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<(IEnumerable<T> Data, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    Task<(IEnumerable<T> Data, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
