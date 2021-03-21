using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class LootLine
    {
        public int Id { get; set; }
        public int? LootTableId { get; set; }
        public int WeaponId { get; set; }
        public int? Quantity { get; set; }
        public decimal? DropPercentage { get; set; }
    }
}
