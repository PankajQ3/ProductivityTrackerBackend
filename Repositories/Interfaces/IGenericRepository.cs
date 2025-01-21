using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProductivityTrackerBackend.Repositories.Interfaces
{
    public interface IGenericRepository<T, TContext>
    where T : class
    where TContext : DbContext
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
