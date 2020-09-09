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

        public IEnumerable<Shared.Travel> GetTravels()
        {
            List<Shared.Travel> final = new List<Shared.Travel>();
            List<Models.Travel> travels = _AirTechContext.Travel.ToList();
            foreach (Models.Travel t in travels)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(t)));
            }
            return final;
        }

        public Shared.Travel GetTravelsById(int id)
        {
            IQueryable<Models.Travel> list = _AirTechContext.Travel.Where(t => t.Id == id);
            Models.Travel t = list.FirstOrDefault<Models.Travel>();
            return ConvertToEndPoint(ConvertToBusiness(t));
        }

        private Business.Travel ConvertToBusiness(Models.Travel model)
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

        private Shared.Travel ConvertToEndPoint(Business.Travel model)
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