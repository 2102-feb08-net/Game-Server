using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class KillStat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModId { get; set; }

        public virtual Mob Mod { get; set; }
        public virtual Player User { get; set; }
    }
}
