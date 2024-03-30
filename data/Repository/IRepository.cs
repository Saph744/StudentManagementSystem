using System.Linq.Expressions;

namespace schoolmanagement.data.Repository
{
    public interface IRepository<T> where T : Domain.Models.BaseEntity
    {
        Task InsertAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
