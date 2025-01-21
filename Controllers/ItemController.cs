using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Services.Interfaces;
using System.Security.Claims;

namespace ProductivityTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/items")]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var items = await _itemService.GetItemsByUserIdAsync(userId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            item.UserId = userId;
            var createdItem = await _itemService.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItems), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item updatedItem)
        {
            updatedItem.Id = id;
            var success = await _itemService.UpdateItemAsync(updatedItem);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var success = await _itemService.DeleteItemAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}
