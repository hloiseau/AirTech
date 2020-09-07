using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public List<Travel> GetTravels()
        {
            throw new NotImplementedException();
        }
    }
}