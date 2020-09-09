
using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        internal async Task<Shared.Billet> CreateBillet(Shared.Billet billet)
        {
            await _AirTechContext.Billet.AddAsync(ConvertToDal(billet));
            await _AirTechContext.SaveChangesAsync();

            List<Models.Billet> billets = _AirTechContext.Billet.OrderByDescending(t => t.Id).ToList();
            Models.Billet final = billets.FirstOrDefault<Models.Billet>();
            return ConvertToEndPoint(final);
        }

        internal Shared.Billet GetBilletsById(int id)
        {
            IQueryable<Models.Billet> list = _AirTechContext.Billet.Where(t => t.Id == id);
            Models.Billet b = list.FirstOrDefault<Models.Billet>();
            return ConvertToEndPoint(ConvertToBusiness(b));
        }

        public static Business.Billet ConvertToBusiness(Models.Billet model)
        {
            return new Business.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId
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
                VoyagerId = model.VoyagerId
            };
        }

        public static Shared.Billet ConvertToEndPoint(Models.Billet model)
        {
            return new Shared.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId
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

        public static ICollection<Shared.Billet> ConvertToEndPoint(ICollection<Models.Billet> models)
        {
            ICollection<Shared.Billet> final = new List<Shared.Billet>();
            foreach (Models.Billet b in models)
            {
                final.Add(ConvertToEndPoint(b));
            }
            return final;
        }

        public static Models.Billet ConvertToDal(Shared.Billet model)
        {
            return new Models.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId
            };
        }

        public static Models.Billet ConvertToDal(Business.Billet model)
        {
            return new Models.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId
            };
        }

        public static ICollection<Models.Billet> ConvertToDal(ICollection<Shared.Billet> models)
        {
            ICollection<Models.Billet> final = new List<Models.Billet>();
            foreach (Shared.Billet b in models)
            {
                final.Add(ConvertToDal(b));
            }
            return final;
        }

        public static ICollection<Models.Billet> ConvertToDal(ICollection<Business.Billet> models)
        {
            ICollection<Models.Billet> final = new List<Models.Billet>();
            foreach (Business.Billet b in models)
            {
                final.Add(ConvertToDal(b));
            }
            return final;
        }
    }
}
