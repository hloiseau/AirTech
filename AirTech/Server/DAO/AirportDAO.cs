using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class AirportDAO
    {
        private DatabaseService _databaseService;

        public AirportDAO(DatabaseService context, ILogger<AirportDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<Business.Airport> GetAirports()
        {
            List<Business.Airport> final = new List<Business.Airport>();
            List<Airport> Airports = _databaseService.Airport.ToList();
            foreach (Airport a in Airports)
            {
                final.Add(
                    new Business.Airport
                    {
                        Name = a.Name
                    }
                ) ;
            }
            return final;
        }
    }
}
