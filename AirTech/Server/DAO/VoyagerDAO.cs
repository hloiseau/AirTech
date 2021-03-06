﻿using AirTech.Server.Models;
using AirTech.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class VoyagerDAO
    {
        private AirTechContext _airTechContext;
        private IntechAirFranceService _intechAirFranceService;


        public VoyagerDAO(AirTechContext context, ILogger<VoyagerDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._airTechContext = context;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Voyager>> GetVoyagers()
        {
            List<Shared.Voyager> final = new List<Shared.Voyager>();
            List<Voyager> voyagers = await _airTechContext.Voyager.ToListAsync();

            foreach (Voyager v in voyagers)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(v, false), false));
            };
            try
            {
                List<Models_IntechAirFrance.Voyager> voyagers2 = await _intechAirFranceService.GetVoyagersAsync();
                foreach (Models_IntechAirFrance.Voyager v in voyagers2)
                {
                    final.Add(ConvertToEndPoint(ConvertToBusiness(v), false));
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
            }
            return final;
        }

        public Shared.Voyager GetVoyagerById(int IdToFind)
        {
            List<Models.Voyager> voyagers = _airTechContext.Voyager.ToList();
            foreach (Models.Voyager v in voyagers)
            {
                if (v.Id == IdToFind)
                {
                    return ConvertToEndPoint(ConvertToBusiness(v, true), true);
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

        public static Business.Voyager ConvertToBusiness(Models.Voyager model, bool fullObject)
        {
            var voyager = new Business.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
            };
            if (fullObject)
                voyager.Billet = BilletDAO.ConvertToBusiness(model.Billet);
            return voyager;
        }
        public static Business.Voyager ConvertToBusiness(Models_IntechAirFrance.Voyager model)
        {
            return new Business.Voyager
            {
                LastName = model.nomPassager,
                FirstName = model.prenomPassager,
            };
        }

        public static Shared.Voyager ConvertToEndPoint(Business.Voyager model, bool fullObject)
        {
            var voyager = new Shared.Voyager
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
            };
            if (fullObject)
                voyager.Billet = BilletDAO.ConvertToEndPoint(model.Billet);
            return voyager;
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
