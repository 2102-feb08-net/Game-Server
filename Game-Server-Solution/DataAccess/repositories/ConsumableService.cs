using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public class ConsumableService
    {
        private readonly IItemRepository _itemRepository;

        public ConsumableService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Consumable GetRandomConsumable()
        {
            List<Consumable> consumables = _itemRepository.GetAllConsumables();
            Random gen = new Random();
            return _itemRepository.GetConsumable(gen.Next(consumables.Count));
        }
    }
}
