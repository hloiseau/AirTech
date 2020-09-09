using System;
using System.Collections.Generic;

namespace AirTech.Server.Models
{
    public partial class Billet
    {
        public int? IdTravel { get; set; }
        public int Id { get; set; }
        public int? IdOrder { get; set; }
        public int? UnitPrice { get; set; }
        public DateTime? Date { get; set; }
        public int? VoyagerId { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Travel IdTravelNavigation { get; set; }
        public virtual Voyager Voyager { get; set; }
    }
}
