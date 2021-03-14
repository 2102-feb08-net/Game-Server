using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Weapon
    {
        public Weapon()
        {
            Lootlines = new HashSet<Lootline>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Damage { get; set; }
        public double? AttackSpeed { get; set; }
        public int? LevelRequirement { get; set; }
        public string Rarity { get; set; }

        public virtual ICollection<Lootline> Lootlines { get; set; }
    }
}
