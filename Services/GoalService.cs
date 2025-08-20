using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<List<Goal>> GetGoalsByUserIdAsync(int userId)
        {
            return await _goalRepository.GetGoalsByUserIdAsync(userId);
        }

        public async Task<Goal> CreateGoalAsync(Goal goal)
        {
            return await _goalRepository.AddAsync(goal);
        }

        public async Task<bool> UpdateGoalAsync(Goal goal)
        {
            return await _goalRepository.UpdateAsync(goal);
        }

        public async Task<bool> DeleteGoalAsync(int id)
        {
            return await _goalRepository.DeleteAsync(id);
        }
    }
}
