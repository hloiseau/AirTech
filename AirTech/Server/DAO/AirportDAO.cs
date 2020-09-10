using AirTech.Server.Models;
using AirTech.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class AirportDAO
    {
        private AirTechContext _AirTechContext;
        private IntechAirFranceService _intechAirFranceService;

        public AirportDAO(AirTechContext context, ILogger<AirportDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechContext = context;
            _intechAirFranceService = intechAirFranceService;
        }

        public async Task<IEnumerable<Shared.Airport>> GetAirports()
        {
            List<Shared.Airport> final = new List<Shared.Airport>();
            List<Models.Aeroport> Airports = await  _AirTechContext.Airport.ToListAsync();
            List<Models_IntechAirFrance.Airport> Airports2 = await _intechAirFranceService.GetAirportsAsync();

            foreach (var a in Airports)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(a)));
            }
            foreach (var a in Airports2)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(a)));
            }
            return final;
        }

        public static Business.Airport ConvertToBusiness(Models.Aeroport model)
        {
            return new Business.Airport
            {
                Name = model.Name
            };
        }

        public static Business.Airport ConvertToBusiness(Models_IntechAirFrance.Airport model)
        {
            return new Business.Airport
            {
                Name = model.nameAeroport
            };
        }

        public static Shared.Airport ConvertToEndPoint(Business.Airport model)
        {
            return new Shared.Airport
            {
                Name = model.Name
            };
        }
    }
}
