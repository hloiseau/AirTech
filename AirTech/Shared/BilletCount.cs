using System;
using System.Collections.Generic;

namespace AirTech.Shared
{
    public partial class BilletCount
    {
        public int? IdBillet { get; set; }
        public int? Count { get; set; }

        public virtual Travel IdBilletNavigation { get; set; }
    }
}
