using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;

namespace AirTech.Server.DAO
{
    public class ClientDAO
    {
        private DatabaseService _databaseService;

        public ClientDAO(DatabaseService context, ILogger<ClientDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<Business.Client> GetUsers()
        {
            List<Business.Client> final = new List<Business.Client>();
            List<Shared.Client> Clients = _databaseService.Client.ToList();
            foreach (Shared.Client a in Clients)
            {
                final.Add(
                    new Business.Client
                    {
                        LastName = a.LastName,
                        FirstName = a.FirstName,
                        Id = a.Id
                    }
                );
            }
            return final;
        }

        //public async Task<Business.Client> CreateUser(Shared.Client user)
        //{
        //    await _databaseService.Client.AddAsync(user);
        //    await _databaseService.SaveChangesAsync();

        //    return user;
        //}
    }
}
