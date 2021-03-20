using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    /// <summary>
    /// Represents a consumable in the game
    /// </summary>
    public class Consumable
    {
        /// <summary>
        /// Consumable's Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the consumable
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Brief description of what the consumable does
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// How long the consumable's effects last
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// How much the consumable increases player's stats
        /// </summary>
        public double Strength { get; set; }

        /// <summary>
        /// What type of consumable it is (healing, health, attack, defense, mana)
        /// </summary>
        public string Type { get; set; }
    }
}
