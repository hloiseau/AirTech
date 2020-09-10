using System;
using System.Collections.Generic;

namespace AirTechAPI.Business
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
