using System;
using System.Collections.Generic;

namespace AirTech.Server.Models_IntechAirFrance
{
    public partial class Travel
    {
        public Travel()
        {
        }

        public string noAeroportDepart { get; set; }
        public string noAeroportArrivee { get; set; }
        public int? prixVol { get; set; }
        public int idVol { get; set; }
        public int? nbrPlaceMax { get; set; }
        public int? nbrBagageMax { get; set; }
    }
}
