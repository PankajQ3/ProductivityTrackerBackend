using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;

namespace ProductivityTrackerBackend.Repositories
{
    public class ItemRepository : GenericRepository<Item, ApplicationDbContext>, IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItemsByUserIdAsync(int userId)
        {
            return await _context.Items.Where(i => i.UserId == userId).ToListAsync();
        }
    }
}
