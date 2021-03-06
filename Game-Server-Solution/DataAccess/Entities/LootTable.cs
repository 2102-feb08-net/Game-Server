using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class LootTable
    {
        public LootTable()
        {
            Lootlines = new HashSet<Lootline>();
            Mobs = new HashSet<Mob>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lootline> Lootlines { get; set; }
        public virtual ICollection<Mob> Mobs { get; set; }
    }
}
