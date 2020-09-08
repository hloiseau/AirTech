using System;
using System.Collections.Generic;

namespace  AirTech.Shared

{
    public partial class Billet
    {
        public int IdUser { get; set; }
        public int? IdBillet { get; set; }

        public virtual Travel IdBilletNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
