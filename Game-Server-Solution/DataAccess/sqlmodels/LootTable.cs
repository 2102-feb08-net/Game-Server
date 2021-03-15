using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class LootTable
    {
        public LootTable()
        {
            Lootlines = new HashSet<Lootline>();
            Mobs = new HashSet<Mob>();
        }

        public int Id { get; set; }
        public int MobId { get; set; }

        public virtual Mob Mob { get; set; }
        public virtual ICollection<Lootline> Lootlines { get; set; }
        public virtual ICollection<Mob> Mobs { get; set; }
    }
}
