using System.Linq.Expressions;

namespace BOL.API.Repository.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression);
    Task<int> CreateAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}
