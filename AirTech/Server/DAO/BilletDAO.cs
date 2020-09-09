using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class BilletDAO
    {
        private DatabaseService _databaseService;

        public BilletDAO(DatabaseService context, ILogger<BilletDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<Business.Billet> GetBillets()
        {
            List<Business.Billet> final = new List<Business.Billet>();
            List<Billet> Billets = _databaseService.Billet.ToList();
            foreach (Billet a in Billets)
            {
                final.Add(
                    new Business.Billet
                    {
                        IdTravel = a.IdTravel,
                        Id = a.Id,
                        IdOrder = a.IdOrder,
                        UnitPrice = a.UnitPrice,
                        Date = a.Date,
                        VoyagerId = a.VoyagerId,
                    }
                );
            }
            return final;
        }
    }

        //public async Task<Billet> CreateBillet(Billet billet)
        //{
        //    await _databaseService.Billet.AddAsync(billet);
        //    //todo: update count
        //    await _databaseService.SaveChangesAsync();
        //    return billet;
        //}
}
