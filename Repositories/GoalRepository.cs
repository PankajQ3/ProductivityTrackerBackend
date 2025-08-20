using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;

namespace ProductivityTrackerBackend.Repositories
{
    public class GoalRepository : GenericRepository<Goal, ApplicationDbContext>, IGoalRepository
    {
        private readonly ApplicationDbContext _context;

        public GoalRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Goal>> GetGoalsByUserIdAsync(int userId)
        {
            return await _context.Goals.Where(g => g.UserId == userId).ToListAsync();
        }
    }
}
