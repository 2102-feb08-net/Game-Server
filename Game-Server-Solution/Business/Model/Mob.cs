using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class Mob
    {
        public int Id { get; set; }
        public int LootTableId { get; set; }
        public int Health { get; set; }
        public int Exp { get; set; }
        public double Attack { get; set; }
        public double? Defense { get; set; }
        public double? Speed { get; set; }
    }
}
