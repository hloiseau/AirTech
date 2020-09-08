using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class BilletDAO
    {
        private DatabaseService _databaseService;

        public BilletDAO(DatabaseService context, ILogger<BilletDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<Billet> GetBillets()
        {
            return _databaseService.Billet;
        }

        public async Task<Billet> CreateBillet(Billet billet)
        {
            await _databaseService.Billet.AddAsync(billet);
            //todo: update count
            await _databaseService.SaveChangesAsync();
            return billet;
        }
    }
}
