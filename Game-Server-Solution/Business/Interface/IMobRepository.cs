using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    /// <summary>
    /// Interface for mob repository
    /// </summary>
    public interface IMobRepository
    {
        /// <summary>
        /// Gets all the mobs that are a part of the game
        /// </summary>
        /// <returns>IEnumerable of mobs</returns>
        IEnumerable<Mob> GetAllMobs();

        ///// <summary>
        ///// Gets the loot table for the mob with the specified id
        ///// </summary>
        ///// <param name="mobId"></param>
        ///// <returns>IEnumerable of LootLine</returns>
        //IEnumerable<LootLine> GetLootTable(int mobId);

        /// <summary>
        /// Gets all the positions that the mobs can spawn on the game world
        /// </summary>
        /// <returns>IEnumerable of MobSpawn</returns>
        IEnumerable<MobSpawn> GetMobSpawns();

        /// <summary>
        /// Gets a possible loot that the mob killed can drop
        /// </summary>
        /// <param name="mobId"></param>
        /// <returns>A Weapon</returns>
        Weapon GetLoot(int mobId);
    }
}
