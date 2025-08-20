using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Services
{
    public class TimeLogService : ITimeLogService
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public TimeLogService(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public async Task<List<TimeLog>> GetTimeLogsByItemIdAsync(int itemId)
        {
            return await _timeLogRepository.GetTimeLogsByItemIdAsync(itemId);
        }

        public async Task<List<TimeLog>> GetTimeLogsByDateRangeAsync(int itemId, DateTime startDate, DateTime endDate)
        {
            return await _timeLogRepository.GetTimeLogsByDateRangeAsync(itemId, startDate, endDate);
        }

        public async Task<TimeLog> CreateTimeLogAsync(TimeLog timeLog)
        {
            return await _timeLogRepository.AddAsync(timeLog);
        }

        public async Task<bool> UpdateTimeLogAsync(TimeLog timeLog)
        {
            return await _timeLogRepository.UpdateAsync(timeLog);
        }

        public async Task<bool> DeleteTimeLogAsync(int id)
        {
            return await _timeLogRepository.DeleteAsync(id);
        }
    }
}
