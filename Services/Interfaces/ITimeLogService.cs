using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Services.Interfaces
{
    public interface ITimeLogService
    {
        Task<List<TimeLog>> GetTimeLogsByItemIdAsync(int itemId);
        Task<List<TimeLog>> GetTimeLogsByDateRangeAsync(int itemId, DateTime startDate, DateTime endDate);
        Task<TimeLog> CreateTimeLogAsync(TimeLog timeLog);
        Task<bool> UpdateTimeLogAsync(TimeLog timeLog);
        Task<bool> DeleteTimeLogAsync(int id);
    }
}
