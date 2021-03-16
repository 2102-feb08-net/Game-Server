using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public interface IItemRepository
    {
        IEnumerable<Weapon> GetAllWeapons();

        Weapon GetWeapon(int id);

        IEnumerable<Consumable> GetAllConsumables();

        Consumable GetConsumable(int id);

        Consumable GetRandomConsumable();


 
    }
}
