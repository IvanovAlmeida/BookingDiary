using System.Threading.Tasks;

using BD.Business.Interfaces;
using BD.Business.Models;

namespace BD.Business.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository, INotificator notificator) : base(notificator)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Add(Item item)
        {
            item = await _itemRepository.Add(item);
            return item;
        }
        public async Task Update(Item item)
        {
            await _itemRepository.Update(item);
        }

        public async Task Disable(int id)
        {
            await _itemRepository.Disable(id);
        }

        public async Task Reactivate(int id)
        {
            await _itemRepository.Reactivate(id);
        }

        public void Dispose()
        {
            _itemRepository.Dispose();
        }
    }
}
