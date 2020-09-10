﻿using AirTechAPI.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Policy;
using System;
using AirTechAPI.Server.Services;

namespace AirTechAPI.Server.DAO
{
    public class ClientDAO
    {
        private AirTechAPIContext _AirTechAPIContext;
        private IntechAirFranceService _intechAirFranceService;


        public ClientDAO(AirTechAPIContext context, ILogger<ClientDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechAPIContext = context;
            _intechAirFranceService = intechAirFranceService;

        }

        public async Task<IEnumerable<Shared.Client>> GetUsers()
        {
            List<Shared.Client> final = new List<Shared.Client>();
            List<Models.Client> Clients = _AirTechAPIContext.Client.ToList();
            List<Models_IntechAirFrance.Client> Clients2 = await _intechAirFranceService.GetClientsAsync();

            foreach (Models.Client c in Clients)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(c)));
            }
            foreach (var a in Clients2)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(a)));
            }
            return final;
        }

        public async Task<Shared.Client> CreateUser(Shared.Client user)
        {
            await _AirTechAPIContext.Client.AddAsync(ConvertToDal(user));
            await _AirTechAPIContext.SaveChangesAsync();

            List<Models.Client> clients = _AirTechAPIContext.Client.OrderByDescending(t => t.Id).ToList();
            Models.Client final = clients.FirstOrDefault<Models.Client>();
            return ConvertToEndPoint(final);
        }

        internal Shared.Client GetUsersById(int id)
        {
            IQueryable<Models.Client> list = _AirTechAPIContext.Client.Where(t => t.Id == id);
            Models.Client c = list.FirstOrDefault<Models.Client>();
            return ConvertToEndPoint(ConvertToBusiness(c));
        }

        public static Business.Client ConvertToBusiness(Models.Client model)
        {
            return new Business.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }
        public static Business.Client ConvertToBusiness(Models_IntechAirFrance.Client model)
        {
            return new Business.Client
            {
                LastName = model.nomClient,
                FirstName = model.prenomClient,
            };
        }

        public static Shared.Client ConvertToEndPoint(Business.Client model)
        {
            return new Shared.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }

        public static Shared.Client ConvertToEndPoint(Models.Client model)
        {
            return new Shared.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }

        public static Models.Client ConvertToDal(Shared.Client model)
        {
            return new Models.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }

        public static Models.Client ConvertToDal(Business.Client model)
        {
            return new Models.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }
    }
}