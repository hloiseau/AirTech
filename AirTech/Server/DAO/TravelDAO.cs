using AirTech.Server.Models;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class TravelDAO
    {
        AirTechContext _databaseService;
        ILogger _logger;

        public TravelDAO(AirTechContext context, ILogger<TravelDAO> logger)
        {
            this._databaseService = context;
            this._logger = logger;
        }

        public IEnumerable<Travel> GetTravels()
        {
            List<Travel> final = new List<Travel>();
            List<Travel> travels = _databaseService.Travel.ToList();
            for (int i = 0; i < travels.Count; i++)
            {
                 final.Add(
                 new Travel
                 {
                 From = travels[i].From,
                 To = travels[i].To,
                 Price = travels[i].Price,
                 Id = travels[i].Id,
                                
                 });
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