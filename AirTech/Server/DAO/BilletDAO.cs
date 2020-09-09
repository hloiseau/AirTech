
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

        public static Business.Billet ConvertToBusiness(Models.Billet model)
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

        public static ICollection<Business.Billet> ConvertToBusiness(ICollection<Models.Billet> models)
        {
            ICollection<Business.Billet> final = new List<Business.Billet>();
            foreach (Models.Billet b in models)
            {
                final.Add(ConvertToBusiness(b));
            }
            return final;
        }

        public static Shared.Billet ConvertToEndPoint(Business.Billet model)
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

        public static ICollection<Shared.Billet> ConvertToEndPoint(ICollection<Business.Billet> models)
        {
            ICollection<Shared.Billet> final = new List<Shared.Billet>();
            foreach (Business.Billet b in models)
            {
                final.Add(ConvertToEndPoint(b));
            }
            return final;
        }
    }
}
