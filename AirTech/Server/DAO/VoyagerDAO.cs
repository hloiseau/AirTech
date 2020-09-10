using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class VoyagerDAO
    {
        private AirTechContext _airTechContext;

        public VoyagerDAO(AirTechContext context, ILogger<VoyagerDAO> logger)
        {
            this._airTechContext = context;
        }

        public IEnumerable<Shared.Voyager> GetVoyagers()
        {
            List<Shared.Voyager> final = new List<Shared.Voyager>();
            List<Voyager> voyagers = _airTechContext.Voyager.ToList();
            foreach(Voyager v in voyagers)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(v)));
            };
            return final;
        }

        public Shared.Voyager GetVoyagerById(int IdToFind)
        {
            List<Models.Voyager> voyagers = _airTechContext.Voyager.ToList();
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
            await _airTechContext.Voyager.AddAsync(ConvertToDal(voyager));
            await _airTechContext.SaveChangesAsync();

            List<Models.Voyager> voyagers = _airTechContext.Voyager.OrderByDescending(t => t.Id).ToList();
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
                Billet = BilletDAO.ConvertToEndPoint(model.Billet
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
