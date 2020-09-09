
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using AirTech.Server.Models;

namespace AirTech.Server.DAO
{
    public class AirportDAO
    {
        private AirTechContext _AirTechContext;

        public AirportDAO(AirTechContext context, ILogger<AirportDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Business.Airport> GetAirports()
        {
            List<Business.Airport> final = new List<Business.Airport>();
            List<Airport> Airports = _AirTechContext.Airport.ToList();
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
