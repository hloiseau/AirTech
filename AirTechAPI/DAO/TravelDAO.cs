using AirTechAPI.Server.Models;
using AirTechAPI.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTechAPI.Server.DAO
{
    public class TravelDAO
    {
        AirTechAPIContext _AirTechAPIContext;
        ILogger _logger;
        private IntechAirFranceService _intechAirFranceService;


        public TravelDAO(AirTechAPIContext context, ILogger<TravelDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechAPIContext = context;
            this._logger = logger;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Travel>> GetTravels()
        {
            List<Shared.Travel> final = new List<Shared.Travel>();
            List<Models.Travel> travels = await _AirTechAPIContext.Travel.ToListAsync();
            List<Models_IntechAirFrance.Travel> travels2 = await _intechAirFranceService.GetTravelsAsync();
            foreach (Models.Travel t in travels)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(t)));
            }
            foreach (Models_IntechAirFrance.Travel t in travels2)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(t)));
            }
            return final;
        }

        public Shared.Travel GetTravelsById(int id)
        {
            IQueryable<Models.Travel> list = _AirTechAPIContext.Travel.Where(t => t.Id == id);
            Models.Travel t = list.FirstOrDefault<Models.Travel>();
            return ConvertToEndPoint(ConvertToBusiness(t));
        }

        public static Business.Travel ConvertToBusiness(Models.Travel model)
        {
            return new Business.Travel
            {
                From = model.From,
                To = model.To,
                Price = model.Price,
                Id = model.Id,
                Stock = model.Stock,
                LuggageStock = model.LuggageStock
            };
        }

        public static Business.Travel ConvertToBusiness(Models_IntechAirFrance.Travel model)
        {
            return new Business.Travel
            {
                From = model.noAeroportDepart,
                To = model.noAeroportArrivee,
                Price = model.prixVol,
                Id = model.idVol,
                Stock = model.nbrPlaceMax,
                LuggageStock = model.nbrBagageMax
            };
        }

        public static Shared.Travel ConvertToEndPoint(Business.Travel model)
        {
            return new Shared.Travel
            {
                From = model.From,
                To = model.To,
                Price = model.Price,
                Id = model.Id,
                Stock = model.Stock,
                LuggageStock = model.LuggageStock
            };
        }
    }
}