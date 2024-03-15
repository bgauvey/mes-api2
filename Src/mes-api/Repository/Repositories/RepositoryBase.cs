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
    public void Create(T entity) => _Context.Set<T>().Add(entity);
    public void Update(T entity) => _Context.Set<T>().Update(entity);
    public void Delete(T entity) => _Context.Set<T>().Remove(entity);
}