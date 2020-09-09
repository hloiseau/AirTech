
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
            foreach (Billet b in Billets)
            {
                final.Add(ConvertToBuisness(b));
            }
            return final;
        }

        //public async Task<Billet> CreateBillet(Billet billet)
        //{
        //    await _AirTechContext.Billet.AddAsync(billet);
        //    //todo: update count
        //    await _AirTechContext.SaveChangesAsync();
        //    return billet;
        //}

        public Business.Billet ConvertToBuisness(Models.Billet model)
        {
            return new Business.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId,
            };
        }

        public Shared.Billet ConvertToEndPoint(Business.Billet model)
        {
            return new Shared.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId,
            };
        }
    }
}
