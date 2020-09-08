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

        public IEnumerable<TravelDispo> GetTravels()
        {
            List<TravelDispo> final = new List<TravelDispo>();
            List<Travel> travels = _databaseService.Travel.ToList();
            List<BilletCount> billetCounts = _databaseService.BilletCount.ToList();

            for (int j = 0; j < billetCounts.Count; j++)
            {
                for (int i = 0; i < travels.Count; i++)
                {
                    if (billetCounts[j].IdBillet == travels[i].Id)
                    {
                        final.Add(
                            new TravelDispo
                            {
                                From = travels[i].From,
                                To = travels[i].To,
                                Price = travels[i].Price,
                                Id = travels[i].Id,
                                Date = travels[i].Date,
                                Quantity = billetCounts[j].Count,
                            });
                    }
                }
            }
            return final;
        }

        public Travel GetTravelsById(int id)
        {
            IQueryable<Travel> list = _databaseService.Travel.Where(t => t.Id == id);
            Travel t = list.FirstOrDefault<Travel>();
            return t;
        }
    }
}