
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

        public IEnumerable<Shared.Billet> GetBillets()
        {
            List<Shared.Billet> final = new List<Shared.Billet>();
            List<Models.Billet> Billets = _AirTechContext.Billet.ToList();
            foreach (Models.Billet b in Billets)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(b)));
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

        private Business.Billet ConvertToBusiness(Models.Billet model)
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

        private Shared.Billet ConvertToEndPoint(Business.Billet model)
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
