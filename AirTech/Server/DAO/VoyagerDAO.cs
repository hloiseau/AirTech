using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System;
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

        public IEnumerable<Business.Voyager> GetVoyager()
        {
            List<Business.Voyager> final = new List<Business.Voyager>();
            List<Voyager> voyagers = _airTechContext.Voyager.ToList();
            foreach(Voyager v in voyagers)
            {
                final.Add(
                    new Business.Voyager
                    {
                        Id = v.Id,
                        LastName = v.LastName,
                        FirstName = v.FirstName
                    }
                );
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
                    return new Business.Voyager
                    {
                        Id = v.Id,
                        LastName = v.LastName,
                        FirstName = v.FirstName
                    };
                }
            }
            return null;
        }
    }
}
