using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class VoyagerDAO
    {
        private AirTechContext _airTechContext;

        public VoyagerDAO(AirTechContext context, ILogger<VoyagerDAO> logger)
        {
            this._airTechContext = context;
        }

        public IEnumerable<Business.Voyager> GetVoyager()
        {
            List<Business.Voyager> final = new List<Business.Voyager>();
            List<Voyager> voyagers = _airTechContext.Voyager.ToList();
            foreach(Voyager v in voyagers)
            {
                final.Add(ConvertToBuisness(v));
            };
            return final;
        }

        public Business.Voyager GetVoyagerById(int IdToFind)
        {
            List<Voyager> voyagers = _airTechContext.Voyager.ToList();
            foreach (Voyager v in voyagers)
            {
                if(v.Id == IdToFind)
                {
                    return ConvertToBuisness(v);
                }
            }
            return null;
        }

        public Business.Voyager ConvertToBuisness(Models.Voyager model)
        {
            return new Business.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
        }

        public Shared.Voyager ConvertToEndPoint(Business.Voyager model)
        {
            return new Shared.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
        }
    }
}
