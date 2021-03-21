using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    /// <summary>
    /// Interface for item repository
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Get all weapons from the database
        /// </summary>
        /// <returns>IEnumerable of all weapons</returns>
        IEnumerable<Weapon> GetAllWeapons();

        /// <summary>
        /// Get a weapon specified by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Weapon</returns>
        Weapon GetWeapon(int id);

        /// <summary>
        /// Gets all consumables from the database
        /// </summary>
        /// <returns>IEnumerable of all consumables</returns>
        IEnumerable<Consumable> GetAllConsumables();

        /// <summary>
        /// Get a consumable specified by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A consumable</returns>
        Consumable GetConsumable(int id);
    }
}
