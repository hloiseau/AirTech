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

        public IEnumerable<Shared.Airport> GetAirports()
        {
            List<Shared.Airport> final = new List<Shared.Airport>();
            List<Models.Airport> Airports = _AirTechContext.Airport.ToList();
            foreach (Models.Airport a in Airports)
            {
                final.Add(ConvertToEndPoint(ConvertToBuisness(a)));
            }
            return final;
        }

        private Business.Airport ConvertToBuisness(Models.Airport model)
        {
            return new Business.Airport
            {
                Name = model.Name
            };
        }

        private Shared.Airport ConvertToEndPoint(Business.Airport model)
        {
            return new Shared.Airport
            {
                Name = model.Name
            };
        }
    }
}
