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

        public IEnumerable<Shared.Voyager> GetVoyager()
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

        private Business.Voyager ConvertToBusiness(Models.Voyager model)
        {
            return new Business.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
        }

        private Shared.Voyager ConvertToEndPoint(Business.Voyager model)
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
