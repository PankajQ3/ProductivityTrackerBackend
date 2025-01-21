using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Repositories.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item, ApplicationDbContext>
    {
        Task<List<Item>> GetItemsByUserIdAsync(int userId);
    }
}
