namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IAsyncRepository<T>
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetQueryAsync();
    Task<T> GetAsync(long id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
}