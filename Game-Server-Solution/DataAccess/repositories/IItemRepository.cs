using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public interface IItemRepository
    {
        List<Weapon> GetAllWeapons();

        Weapon GetWeapon(int id);

        List<Consumable> GetAllConsumables();

        Consumable GetConsumable(int id);

    }
}
