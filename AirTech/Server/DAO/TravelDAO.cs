using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class TravelDAO
    {
        DatabaseService _databaseService;
        ILogger _logger;

        public TravelDAO(DatabaseService context, ILogger<TravelDAO> logger)
        {
            this._databaseService = context;
            this._logger = logger;
        }

        public IEnumerable<Business.Travel> GetTravels()
        {
            List<Business.Travel> final = new List<Business.Travel>();
            List<Travel> travels = _databaseService.Travel.ToList();
            foreach (Shared.Travel a in travels)
            {
                final.Add(
                new Business.Travel
                {
                    From = a.From,
                    To = a.To,
                    Price = a.Price,
                    Id = a.Id,
                    Stock = a.Stock

                });
            }

            return final;
        }

        public Business.Travel GetTravelsById(int id)
        {
            IQueryable<Travel> list = _databaseService.Travel.Where(t => t.Id == id);
            Travel t = list.FirstOrDefault<Travel>();
            return new Business.Travel
            {
                From = t.From,
                To = t.To,
                Price = t.Price,
                Id = t.Id,
                Stock = t.Stock
            };
        }
    }
}