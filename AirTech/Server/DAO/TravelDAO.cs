using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class TravelDAO
    {
        AirTechContext _AirTechContext;
        ILogger _logger;

        public TravelDAO(AirTechContext context, ILogger<TravelDAO> logger)
        {
            this._AirTechContext = context;
            this._logger = logger;
        }

        public IEnumerable<Business.Travel> GetTravels()
        {
            List<Business.Travel> final = new List<Business.Travel>();
            List<Models.Travel> travels = _AirTechContext.Travel.ToList();
            foreach (Models.Travel t in travels)
            {
                final.Add(ConvertToBuisness(t));
            }
            return final;
        }

        public Business.Travel GetTravelsById(int id)
        {
            IQueryable<Models.Travel> list = _AirTechContext.Travel.Where(t => t.Id == id);
            Models.Travel t = list.FirstOrDefault<Models.Travel>();
            return ConvertToBuisness(t);
        }

        public Business.Travel ConvertToBuisness(Models.Travel model)
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
        
        public Shared.Travel ConvertToEndPoint(Business.Travel model)
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