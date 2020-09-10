using AirTechAPI.Server.Models;
using AirTechAPI.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTechAPI.Server.DAO
{
    public class VoyagerDAO
    {
        private AirTechAPIContext _AirTechAPIContext;
        private IntechAirFranceService _intechAirFranceService;


        public VoyagerDAO(AirTechAPIContext context, ILogger<VoyagerDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechAPIContext = context;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Voyager>> GetVoyagers()
        {
            List<Shared.Voyager> final = new List<Shared.Voyager>();
            List<Voyager> voyagers = await  _AirTechAPIContext.Voyager.ToListAsync();
            List<Models_IntechAirFrance.Voyager> voyagers2 = await _intechAirFranceService.GetVoyagersAsync();

            foreach (Voyager v in voyagers)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(v)));
            };

            foreach (var v in voyagers2)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(v)));
            };
            return final;
        }

        public Shared.Voyager GetVoyagerById(int IdToFind)
        {
            List<Models.Voyager> voyagers = _AirTechAPIContext.Voyager.ToList();
            foreach (Models.Voyager v in voyagers)
            {
                if(v.Id == IdToFind)
                {
                    return ConvertToEndPoint(ConvertToBusiness(v));
                }
            }
            return null;
        }

        public async Task<Shared.Voyager> CreateVoyagerAsync(Shared.Voyager voyager)
        {
            await _AirTechAPIContext.Voyager.AddAsync(ConvertToDal(voyager));
            await _AirTechAPIContext.SaveChangesAsync();

            List<Models.Voyager> voyagers = _AirTechAPIContext.Voyager.OrderByDescending(t => t.Id).ToList();
            Models.Voyager final = voyagers.FirstOrDefault<Models.Voyager>();
            return ConvertToEndPoint(final);
        }

        public static Business.Voyager ConvertToBusiness(Models.Voyager model)
        {
            return new Business.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Billet = BilletDAO.ConvertToBusiness(model.Billet)
            };
        }
        public static Business.Voyager ConvertToBusiness(Models_IntechAirFrance.Voyager model)
        {
            return new Business.Voyager
            {
                LastName = model.nomPassager,
                FirstName = model.prenomPassager,
            };
        }

        public static Shared.Voyager ConvertToEndPoint(Business.Voyager model)
        {
            return new Shared.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Billet = BilletDAO.ConvertToEndPoint(model.Billet)
            };
        }
        public static Shared.Voyager ConvertToEndPoint(Models.Voyager model)
        {
            return new Shared.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Billet = BilletDAO.ConvertToEndPoint(model.Billet)
            };
        }

        public static Models.Voyager ConvertToDal(Shared.Voyager model)
        {
            return new Models.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Billet = BilletDAO.ConvertToDal(model.Billet)
            };
        }
    }
}
