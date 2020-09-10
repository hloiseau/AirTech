using System;
using System.Collections.Generic;

namespace AirTech.Server.Models_IntechAirFrance
{
    public partial class Billet
    {
        public int? idPassager { get; set; }
        public int idVol { get; set; }
        public int? idCommande { get; set; }
        public DateTime? dateDepart { get; set; }
        public DateTime? dateArrivee { get; set; }
    }
}
