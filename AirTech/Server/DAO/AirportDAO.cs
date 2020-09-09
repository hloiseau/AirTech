using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
                final.Add(ConvertToBuisness(a));
            }
            return final;
        }

        public Business.Airport ConvertToBuisness(Models.Airport model)
        {
            return new Business.Airport
            {
                Name = model.Name
            };
        }

        public Shared.Airport ConvertToEndPoint(Business.Airport model)
        {
            return new Shared.Airport
            {
                Name = model.Name
            };
        }
    }
}
