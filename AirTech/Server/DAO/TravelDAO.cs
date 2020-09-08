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
            IEnumerable<Travel> a = _databaseService.Travel;
            List<Travel> aa = a.ToList();
            IEnumerable<BilletCount> b = _databaseService.BilletCount;
            foreach (BilletCount bc in b)
            {
                for (int i = 0; i < aa.Count; i++)
                {
                    if (bc.IdBillet == aa[i].Id)
                    {
                        final.Add(
                            new TravelDispo
                            {
                                From = aa[i].From,
                                To = aa[i].To,
                                Price = aa[i].Price,
                                Id = aa[i].Id,
                                Date = aa[i].Date,
                                Quantity = bc.Count,
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