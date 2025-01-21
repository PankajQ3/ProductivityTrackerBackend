using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Services
{
    public interface ItemService
    {
        public class ItemService : IItemService
        {
            private readonly IItemRepository _itemRepository;

            public ItemService(IItemRepository itemRepository)
            {
                _itemRepository = itemRepository;
            }

            public async Task<List<Item>> GetItemsByUserIdAsync(int userId)
            {
                return await _itemRepository.GetItemsByUserIdAsync(userId);
            }

            public async Task<Item> CreateItemAsync(Item item)
            {
                return await _itemRepository.AddAsync(item);
            }

            public async Task<bool> UpdateItemAsync(Item item)
            {
                return await _itemRepository.UpdateAsync(item);
            }

            public async Task<bool> DeleteItemAsync(int id)
            {
                return await _itemRepository.DeleteAsync(id);
            }
        }
    }
}
