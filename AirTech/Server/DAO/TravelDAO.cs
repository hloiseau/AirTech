using AirTech.Server.Models;
using AirTech.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class TravelDAO
    {
        AirTechContext _AirTechContext;
        ILogger _logger;
        private IntechAirFranceService _intechAirFranceService;


        public TravelDAO(AirTechContext context, ILogger<TravelDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechContext = context;
            this._logger = logger;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Travel>> GetTravels()
        {
            List<Shared.Travel> final = new List<Shared.Travel>();
            List<Models.Travel> travels = await _AirTechContext.Travel.ToListAsync();
          
            foreach (Models.Travel t in travels)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(t)));
            }
            try
            {
                List<Models_IntechAirFrance.Travel> travels2 = await _intechAirFranceService.GetTravelsAsync();
                foreach (Models_IntechAirFrance.Travel t in travels2)
                {
                    final.Add(ConvertToEndPoint(ConvertToBusiness(t)));
                }
            }
            catch { }
            
           
            return final;
        }

        public Shared.Travel GetTravelsById(int id)
        {
            IQueryable<Models.Travel> list = _AirTechContext.Travel.Where(t => t.Id == id);
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