using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Project2Context _context;

        public ItemRepository(Project2Context context)
        {
            _context = context;
        }
        public IEnumerable<Weapon> GetAllWeapons()
        {
            throw new NotImplementedException();
        }

        public Weapon GetWeapon(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consumable> GetAllConsumables()
        {
            throw new NotImplementedException();
        }

        public Consumable GetConsumable(int id)
        {
            throw new NotImplementedException();
        }

        public Consumable GetRandomConsumable()
        {
            throw new NotImplementedException();
        }
    }
}
