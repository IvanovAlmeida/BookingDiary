using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using BD.Business.Interfaces;
using BD.Business.Models;

namespace BD.Business.Services
{
    public class ReserveService : BaseService, IReserveService
    {
        private readonly IReserveRepository _reserveRepository;
        private readonly IReserveItemRepository _reserveItemRepository;
        private readonly IItemRepository _itemRepository;

        public ReserveService(IReserveRepository reserveRepository, INotificator notificator,
            IItemRepository itemRepository, IReserveItemRepository reserveItemRepository) : base(notificator)
        {
            _reserveRepository = reserveRepository;
            _itemRepository = itemRepository;
            _reserveItemRepository = reserveItemRepository;
        }

        public async Task<Reserve> Add(Reserve reserve)
        {
            Expression<Func<Reserve, bool>> pred = re => 
                    re.DateStart.CompareTo(reserve.DateStart) >= 0
                    && re.DateEnd.CompareTo(reserve.DateStart) <= 0;

            var r = await _reserveRepository.Find(pred);
            if(r.Any())
            {
                Notify("Já exite uma Reserva nesse período!");
                return null;
            }

            var itemsIds = reserve.ReserveItem.Select(ri => ri.ItemId);
            var items = await _itemRepository
                                .Find(i => itemsIds.Contains(i.Id) && i.DisabledAt == null);

            if(items.Count() != itemsIds.Count())
            {
                Notify("Um ou mais itens não existem ou não estão disponíveis!");
                return null;
            }

            reserve = await _reserveRepository.Add(reserve);
            return reserve;
        }

        public async Task Update(Reserve reserve)
        {
            Expression<Func<Reserve, bool>> pred = re =>
                    re.Id != reserve.Id
                    && re.DateStart.CompareTo(reserve.DateStart) >= 0
                    && re.DateEnd.CompareTo(reserve.DateStart) <= 0;

            var r = await _reserveRepository.Find(pred);
            if (r.Any())
            {
                Notify("Já exite uma Reserva nesse período!");
                return;
            }

            var itemsIds = reserve.ReserveItem.Select(ri => ri.ItemId);
            var items = await _itemRepository
                                .Find(i => itemsIds.Contains(i.Id) && i.DisabledAt == null);

            if (items.Count() != itemsIds.Count())
            {
                Notify("Um ou mais itens não existem ou não estão disponíveis!");
                return;
            }

            var reserveItems = await _reserveRepository.GetByIdWithItems(reserve.Id);

            var reserveItemsId = reserve.ReserveItem.Select(ri => ri.IdReserveItem);
            var itemsToRemove = reserveItems
                                .ReserveItem
                                .Where(ri => !reserveItemsId.Contains(ri.IdReserveItem))
                                .ToList();

            await _reserveItemRepository.ForceRemove(itemsToRemove);

            await _reserveRepository.Update(reserve);
        }

        public async Task Disable(int id)
        {
            await _reserveRepository.Disable(id);
        }

        public async Task Reactivate(int id)
        {
            await _reserveRepository.Reactivate(id);
        }

        public void Dispose()
        {
            _reserveRepository.Dispose();
        }
    }
}
