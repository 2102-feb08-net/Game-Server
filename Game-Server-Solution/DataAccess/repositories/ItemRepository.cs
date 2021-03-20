using Business.Interface;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Project2Context _context;

        public ItemRepository(Project2Context context)
        {
            _context = context;
        }

        public IEnumerable<Business.Model.Consumable> GetAllConsumables()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Business.Model.Weapon> GetAllWeapons()
        {
            throw new NotImplementedException();
        }

        public Business.Model.Consumable GetConsumable(int id)
        {
            throw new NotImplementedException();
        }

        public Business.Model.Weapon GetWeapon(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
