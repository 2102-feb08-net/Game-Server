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
        public List<Weapon> GetAllWeapons()
        {
            List<Weapon> weapons = _context.Weapons
                .Select(c => c).ToList();
            return weapons;
        }

        public Weapon GetWeapon(int id)
        {
             Weapon weapon = _context.Weapons
                .Select(w => w)
                .Where(w => w.Id == id).First();

            return weapon;
        }

        public List<Consumable> GetAllConsumables()
        {
            List<Consumable> consumables = _context.Consumables
                .Select(c => c).ToList();
            return consumables;
        }

        public Consumable GetConsumable(int id)
        {
            Consumable consumable = _context.Consumables
                .Select(c => c)
                .Where(c => c.Id == id).First();
            return consumable;
        }
    }
}
