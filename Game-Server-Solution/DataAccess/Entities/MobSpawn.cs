using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class MobSpawn
    {
        public int Id { get; set; }
        public int ModId { get; set; }
        public double SpawnX { get; set; }
        public double SpawnY { get; set; }

        public virtual Mob Mod { get; set; }
    }
}
