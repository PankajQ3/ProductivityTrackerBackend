using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;

namespace ProductivityTrackerBackend.Repositories
{
    public class TimeLogRepository : GenericRepository<TimeLog, ApplicationDbContext>, ITimeLogRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeLogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TimeLog>> GetTimeLogsByItemIdAsync(int itemId)
        {
            return await _context.TimeLogs
                .Where(t => t.ItemId == itemId)
                .ToListAsync();
        }

        public async Task<List<TimeLog>> GetTimeLogsByDateRangeAsync(int itemId, DateTime startDate, DateTime endDate)
        {
            return await _context.TimeLogs
                .Where(t => t.ItemId == itemId && t.StartTime >= startDate && (t.EndTime ?? DateTime.MaxValue) <= endDate)
                .ToListAsync();
        }
    }
}
