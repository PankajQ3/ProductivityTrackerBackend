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
