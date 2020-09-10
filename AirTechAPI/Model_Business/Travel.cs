using System;
using System.Collections.Generic;

namespace AirTechAPI.Business
{
    public partial class Travel
    {
        public Travel()
        {
            Billet = new HashSet<Billet>();
        }

        public string From { get; set; }
        public string To { get; set; }
        public int? Price { get; set; }
        public int Id { get; set; }
        public int? Stock { get; set; }
        public int? LuggageStock { get; set; }

        public virtual Airport FromNavigation { get; set; }
        public virtual Airport ToNavigation { get; set; }
        public virtual ICollection<Billet> Billet { get; set; }
    }
}
