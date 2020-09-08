using AirTech.Server.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class BilletCountDAO
    {
        private DatabaseService _databaseService;

        public BilletCountDAO(DatabaseService context, ILogger<BilletCountDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<BilletCount> GetBilletCounts()
        {
            return _databaseService.BilletCount;
        }
    }
}
