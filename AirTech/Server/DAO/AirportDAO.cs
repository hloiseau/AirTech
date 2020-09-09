﻿using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class AirportDAO
    {
        private AirTechContext _AirTechContext;

        public AirportDAO(AirTechContext context, ILogger<AirportDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Shared.Airport> GetAirports()
        {
            List<Shared.Airport> final = new List<Shared.Airport>();
            List<Models.Airport> Airports = _AirTechContext.Airport.ToList();
            foreach (Models.Airport a in Airports)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(a)));
            }
            return final;
        }

        public static Business.Airport ConvertToBusiness(Models.Airport model)
        {
            return new Business.Airport
            {
                Name = model.Name
            };
        }

        public static Shared.Airport ConvertToEndPoint(Business.Airport model)
        {
            return new Shared.Airport
            {
                Name = model.Name
            };
        }
    }
}
