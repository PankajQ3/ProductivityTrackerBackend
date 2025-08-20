using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Repositories.Interfaces
{
    public interface ITimeLogRepository : IGenericRepository<TimeLog, ApplicationDbContext>
    {
        Task<List<TimeLog>> GetTimeLogsByItemIdAsync(int itemId);
        Task<List<TimeLog>> GetTimeLogsByDateRangeAsync(int itemId, DateTime startDate, DateTime endDate);
    }
}
