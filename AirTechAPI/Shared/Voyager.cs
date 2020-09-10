using System;
using System.Collections.Generic;

namespace AirTechAPI.Shared
{
    public partial class Voyager
    {
        public Voyager()
        {
            Billet = new HashSet<Billet>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Billet> Billet { get; set; }
    }
}
