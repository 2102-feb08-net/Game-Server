using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class Lootline
    {
        public int Id { get; set; }
        public int? LootTableId { get; set; }
        public int WeaponId { get; set; }
        public int? Quantity { get; set; }
        public double? DropPercentage { get; set; }

        public virtual LootTable LootTable { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
