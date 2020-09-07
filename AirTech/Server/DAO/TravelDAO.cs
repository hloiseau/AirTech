using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            foreach (Travel t in _databaseService.Travels)
            {
                if (t.ID == id)
                    return t;
            }
            return null;
        }
    }
}