﻿using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
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

        public IEnumerable<Travel> GetTravels()
        {
            return _databaseService.Travels;
        }

        public Travel GetTravelsById(int id)
        {
            IQueryable<Travel> list = _databaseService.Travels.Where(t => t.ID == id);
            Travel t = list.FirstOrDefault<Travel>();
            return t;

        }
    }
}