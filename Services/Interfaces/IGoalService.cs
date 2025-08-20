using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Services.Interfaces
{
    public interface IGoalService
    {
        Task<List<Goal>> GetGoalsByUserIdAsync(int userId);
        Task<Goal> CreateGoalAsync(Goal goal);
        Task<bool> UpdateGoalAsync(Goal goal);
        Task<bool> DeleteGoalAsync(int id);
    }
}
