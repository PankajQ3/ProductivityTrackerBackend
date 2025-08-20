using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/timelogs")]
    [Authorize]
    public class TimeLogController : ControllerBase
    {
        private readonly ITimeLogService _timeLogService;

        public TimeLogController(ITimeLogService timeLogService)
        {
            _timeLogService = timeLogService;
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetTimeLogsByItemId(int itemId)
        {
            var timeLogs = await _timeLogService.GetTimeLogsByItemIdAsync(itemId);
            return Ok(timeLogs);
        }

        [HttpGet("item/{itemId}/daterange")]
        public async Task<IActionResult> GetTimeLogsByDateRange(int itemId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var timeLogs = await _timeLogService.GetTimeLogsByDateRangeAsync(itemId, startDate, endDate);
            return Ok(timeLogs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeLog([FromBody] TimeLog timeLog)
        {
            var createdTimeLog = await _timeLogService.CreateTimeLogAsync(timeLog);
            return CreatedAtAction(nameof(GetTimeLogsByItemId), new { itemId = createdTimeLog.ItemId }, createdTimeLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeLog(int id, [FromBody] TimeLog timeLog)
        {
            if (id != timeLog.Id) return BadRequest();

            var success = await _timeLogService.UpdateTimeLogAsync(timeLog);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeLog(int id)
        {
            var success = await _timeLogService.DeleteTimeLogAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }

}
