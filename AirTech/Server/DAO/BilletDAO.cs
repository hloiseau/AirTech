
using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class BilletDAO
    {
        private AirTechContext _AirTechContext;

        public BilletDAO(AirTechContext context, ILogger<BilletDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Business.Billet> GetBillets()
        {
            List<Business.Billet> final = new List<Business.Billet>();
            List<Billet> Billets = _AirTechContext.Billet.ToList();
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
        //    await _AirTechContext.Billet.AddAsync(billet);
        //    //todo: update count
        //    await _AirTechContext.SaveChangesAsync();
        //    return billet;
        //}
}
