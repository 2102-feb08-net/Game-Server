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
            //randomGen = new Random();
        }

        public void GetRandomConsumable()
        {
            
        }
    }
}
