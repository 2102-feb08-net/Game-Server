using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class KillStat
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MobId { get; set; }
        public int? Quantity { get; set; }

        public virtual Mob Mob { get; set; }
        public virtual Player Player { get; set; }
    }
}
