using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Consumable
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Strength { get; set; }
        public string Type { get; set; }
    }
}
