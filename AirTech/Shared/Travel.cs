using System;
using System.Collections.Generic;

namespace AirTech.Shared
{
    public partial class Travel
    {
        public string From { get; set; }
        public string To { get; set; }
        public int? Price { get; set; }
        public int Id { get; set; }
        public DateTime? Date { get; set; }

        public virtual Airport FromNavigation { get; set; }
        public virtual Airport ToNavigation { get; set; }
    }
}
