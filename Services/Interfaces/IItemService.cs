using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Services.Interfaces
{
    public interface IItemService
    {
        Task<List<Item>> GetItemsByUserIdAsync(int userId);
        Task<Item> CreateItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(int id);
    }
}
