namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;
public class RepositoryBase<T> : IAsyncRepository<T> where T : class
{
    protected readonly ApplicationDbContext context;
    public RepositoryBase(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<T> AddAsync(T entity)
    {

        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;

    }

    public async Task<T> DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetAsync(long id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities); // Add a range of entities
        await context.SaveChangesAsync();    // Save changes asynchronously
        return entities;                     // Return the added entities
    }
    public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
    {
        context.UpdateRange(entities); // Add a range of entities
        await context.SaveChangesAsync();    // Save changes asynchronously
        return entities;                     // Return the added entities
    }

    public IQueryable<T> GetQueryAsync()
    {
        return context.Set<T>();
    }
}
