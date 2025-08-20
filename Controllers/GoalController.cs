using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/goals")]
    [Authorize]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }


        /// <summary>
        /// Get goals by user ID
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetGoalsByUserId(int userId)
        {
            var goals = await _goalService.GetGoalsByUserIdAsync(userId);
            return Ok(goals);
        }

        /// <summary>
        /// Get a goal by its ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById(int id)
        {
            var goal = await _goalService.GetGoalsByUserIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        /// <summary>
        /// Create a new goal
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] Goal goal)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdGoal = await _goalService.CreateGoalAsync(goal);
            return CreatedAtAction(nameof(GetGoalById), new { id = createdGoal.Id }, createdGoal);
        }

        /// <summary>
        /// Update an existing goal
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] Goal goal)
        {
            if (id != goal.Id) return BadRequest();

            var success = await _goalService.UpdateGoalAsync(goal);
            if (!success) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete a goal
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var success = await _goalService.DeleteGoalAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }


}
