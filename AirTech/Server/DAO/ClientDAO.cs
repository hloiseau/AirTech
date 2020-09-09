using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Policy;
using System;

namespace AirTech.Server.DAO
{
    public class ClientDAO
    {
        private AirTechContext _AirTechContext;

        public ClientDAO(AirTechContext context, ILogger<ClientDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Shared.Client> GetUsers()
        {
            List<Shared.Client> final = new List<Shared.Client>();
            List<Models.Client> Clients = _AirTechContext.Client.ToList();
            foreach (Models.Client c in Clients)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(c)));
            }
            return final;
        }

        public async Task<Shared.Client> CreateUser(Shared.Client user)
        {
            await _AirTechContext.Client.AddAsync(ConvertToDal(user));
            await _AirTechContext.SaveChangesAsync();

            List<Models.Client> clients = _AirTechContext.Client.OrderByDescending(t => t.Id).ToList();
            Models.Client final = clients.FirstOrDefault<Models.Client>();
            return ConvertToEndPoint(final);
        }

        internal Shared.Client GetUsersById(int id)
        {
            IQueryable<Models.Client> list = _AirTechContext.Client.Where(t => t.Id == id);
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
