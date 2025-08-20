using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Services.Interfaces
{
    public interface IItemService
    {
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(int id);
    }
}
