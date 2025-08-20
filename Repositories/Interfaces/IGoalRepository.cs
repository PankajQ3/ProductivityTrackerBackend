using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Repositories.Interfaces
{
    public interface IGoalRepository : IGenericRepository<Goal, ApplicationDbContext>
    {
        Task<List<Goal>> GetGoalsByUserIdAsync(int userId);
    }
}
