
using AirTech.Server.Models;
using AirTech.Server.Services;
using Microsoft.EntityFrameworkCore;
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
        private IntechAirFranceService _intechAirFranceService;


        public BilletDAO(AirTechContext context, ILogger<BilletDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechContext = context;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Billet>> GetBillets()
        {
            List<Shared.Billet> final = new List<Shared.Billet>();
            List<Models.Billet> Billets = await _AirTechContext.Billet.Include(x=> x.Voyager).ToListAsync();

            foreach (Models.Billet b in Billets)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(b)));
            }
            try
            {
                List<Models_IntechAirFrance.Billet> Billet2 = await _intechAirFranceService.GetBilletsAsync();
                foreach (Models_IntechAirFrance.Billet b in Billet2)
                {
                    final.Add(ConvertToEndPoint(ConvertToBusiness(b)));
                }
            }
            catch { }

            return final;
        }

        internal async Task<Shared.Billet> CreateBillet(Shared.Billet billet)
        {
            await _AirTechContext.Billet.AddAsync(ConvertToDal(billet));
            await _AirTechContext.SaveChangesAsync();

            List<Models.Billet> billets = _AirTechContext.Billet.Include(x=> x.Voyager).OrderByDescending(t => t.Id).ToList();
            Models.Billet final = billets.FirstOrDefault<Models.Billet>();
            return ConvertToEndPoint(final);
        }

        internal Shared.Billet GetBilletsById(int id)
        {
            IQueryable<Models.Billet> list = _AirTechContext.Billet.Include(x => x.Voyager).Where(t => t.Id == id);
            Models.Billet b = list.FirstOrDefault<Models.Billet>();
            return ConvertToEndPoint(ConvertToBusiness(b));
        }

        public static Business.Billet ConvertToBusiness(Models.Billet model)
        {
            var bil = new Business.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId
            };

            if (model.Voyager != null)
                bil.Voyager = VoyagerDAO.ConvertToBusiness(model.Voyager, false);
            return bil;
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
        public static Business.Billet ConvertToBusiness(Models_IntechAirFrance.Billet model)
        {
            return new Business.Billet
            {
                IdTravel = model.idVol,
                IdOrder = model.idCommande,
                Date = model.dateDepart,
                VoyagerId = model.idPassager,
            };
        }

        public static ICollection<Business.Billet> ConvertToBusiness(ICollection<Models_IntechAirFrance.Billet> models)
        {
            ICollection<Business.Billet> final = new List<Business.Billet>();
            foreach (Models_IntechAirFrance.Billet b in models)
            {
                final.Add(ConvertToBusiness(b));
            }
            return final;
        }

        public static Shared.Billet ConvertToEndPoint(Business.Billet model)
        {
            var bil = new Shared.Billet
            {
                IdTravel = model.IdTravel,
                Id = model.Id,
                IdOrder = model.IdOrder,
                UnitPrice = model.UnitPrice,
                Date = model.Date,
                VoyagerId = model.VoyagerId,
            };
            if (model.Voyager != null)
                bil.Voyager = VoyagerDAO.ConvertToEndPoint(model.Voyager, false);
            return bil;

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
                VoyagerId = model.VoyagerId,
                Voyager = VoyagerDAO.ConvertToEndPoint(model.Voyager)
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
