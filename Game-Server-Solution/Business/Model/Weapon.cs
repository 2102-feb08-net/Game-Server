using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    /// <summary>
    /// Represents a weapon that mobs can drop and players can equip
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Id of the weapon
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the weapon
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Brief description of what the weapon is
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// How much damage the weapon does
        /// </summary>
        public double Damage { get; set; }

        /// <summary>
        /// How fast you can attack with this weapon
        /// </summary>
        public double? AttackSpeed { get; set; }

        /// <summary>
        /// How much levels you must have to equip the weapon
        /// </summary>
        public int? LevelRequirement { get; set; }

        /// <summary>
        /// How rare the weapon is to drop from mobs
        /// </summary>
        public string Rarity { get; set; }
    }
}
