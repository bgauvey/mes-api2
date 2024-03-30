using System.Linq.Expressions;
using BOL.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected FactelligenceContext _Context { get; set; }
    protected ILogger _Logger { get; set; }

    public RepositoryBase(FactelligenceContext factelligenceContext, ILoggerFactory loggerFactory)
    {
        _Context = factelligenceContext;
        _Logger = loggerFactory.CreateLogger(nameof(T));
    }

    public IQueryable<T> GetAll() => _Context.Set<T>().AsNoTracking();

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
        _Context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity)
    {
        _Context.Set<T>().Add(entity);
        _Context.SaveChanges();
    }

    public void Update(T entity)
    {
        _Context.Set<T>().Update(entity);
        _Context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _Context.Set<T>().Remove(entity);
        _Context.SaveChanges();
    }

    // Asyncronous Methods

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _Context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _Context.Set<T>().Where(expression).AsNoTracking().SingleAsync();
    }

    public async Task<int> CreateAsync(T entity)
    {
        _Context.Set<T>().Add(entity);
        return await _Context.SaveChangesAsync();
    }
    public async Task<int> DeleteAsync(T entity)
    {
        _Context.Set<T>().Remove(entity);
        return await _Context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _Context.Set<T>().Update(entity);
        return await _Context.SaveChangesAsync();
    }
}