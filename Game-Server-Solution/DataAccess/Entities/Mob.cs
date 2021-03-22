using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Mob
    {
        public Mob()
        {
            KillStats = new HashSet<KillStat>();
        }

        public int Id { get; set; }
        public int? Mobid { get; set; }
        public string Name { get; set; }
        public int? LootTableId { get; set; }
        public int? Health { get; set; }
        public int? Exp { get; set; }
        public double? Attack { get; set; }
        public double? Defense { get; set; }
        public double? Speed { get; set; }

        public virtual LootTable LootTable { get; set; }
        public virtual ICollection<KillStat> KillStats { get; set; }
    }
}
