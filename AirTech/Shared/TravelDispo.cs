using System;
using System.Collections.Generic;
using System.Text;

namespace AirTech.Shared
{
    public class TravelDispo
    {
        public string From { get; set; }
        public string To { get; set; }
        public int? Price { get; set; }
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
    }
}
