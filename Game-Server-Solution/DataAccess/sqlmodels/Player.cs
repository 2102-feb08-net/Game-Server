using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Player
    {
        public Player()
        {
            KillStats = new HashSet<KillStat>();
        }

        public int Id { get; set; }
        public int? CharacterId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Character Character { get; set; }
        public virtual ICollection<KillStat> KillStats { get; set; }
    }
}
