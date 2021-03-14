using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Character
    {
        public Character()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int? Exp { get; set; }
        public int? Health { get; set; }
        public double? Attack { get; set; }
        public double? Defense { get; set; }
        public int? Mana { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
