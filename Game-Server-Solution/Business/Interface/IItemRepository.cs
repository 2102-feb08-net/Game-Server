using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Weapon> GetAllWeapons();

        Weapon GetWeapon(int id);

        IEnumerable<Consumable> GetAllConsumables();

        Consumable GetConsumable(int id);
    }
}
