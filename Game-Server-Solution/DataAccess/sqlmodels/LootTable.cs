using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class LootTable
    {
        public LootTable()
        {
            Mobs = new HashSet<Mob>();
        }

        public int Id { get; set; }

        public virtual ICollection<Mob> Mobs { get; set; }
    }
}
