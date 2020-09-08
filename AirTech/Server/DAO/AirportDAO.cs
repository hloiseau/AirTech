using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AirTech.Server.DAO
{
    public class AirportDAO
    {
        private DatabaseService _databaseService;

        public AirportDAO(DatabaseService context, ILogger<AirportDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<Airport> GetAirports()
        {
            return _databaseService.Airport;
        }
    }
}
