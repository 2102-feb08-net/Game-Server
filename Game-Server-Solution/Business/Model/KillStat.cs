using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    /// <summary>
    /// Represents the amount of times the player has killed a mob.
    /// </summary>
    public class KillStat
    {
        /// <summary>
        /// KillStat id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Player id.
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Mob id.
        /// </summary>
        public int MobId { get; set; }

        /// <summary>
        /// Number of times this mob was killed.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Updates the quantity by incrementing it by 1.
        /// </summary>
        public void UpdateQuantity()
        {
            Quantity++;
        }
    }
}
