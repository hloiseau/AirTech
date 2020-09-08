using System;
using System.Collections.Generic;

namespace AirTech.Shared
{
    public partial class Airport
    {
        public Airport()
        {
            TravelFromNavigation = new HashSet<Travel>();
            TravelToNavigation = new HashSet<Travel>();
        }

        public string Name { get; set; }

        public virtual ICollection<Travel> TravelFromNavigation { get; set; }
        public virtual ICollection<Travel> TravelToNavigation { get; set; }
    }
}
