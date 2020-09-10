using System;
using System.Collections.Generic;

namespace AirTech.Server.Models
{
    public partial class Aeroport
    {
        public Aeroport()
        {
            TravelFromNavigation = new HashSet<Travel>();
            TravelToNavigation = new HashSet<Travel>();
        }

        public string Name { get; set; }

        public virtual ICollection<Travel> TravelFromNavigation { get; set; }
        public virtual ICollection<Travel> TravelToNavigation { get; set; }
    }
}
