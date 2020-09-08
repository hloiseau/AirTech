using System;
using System.Collections.Generic;
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

        public IEnumerable<Shared.Client> GetUsers()
        {
            return _databaseService.Client;
        }

        public async Task<Shared.Client> CreateUser(Shared.Client user)
        {
            await _databaseService.Client.AddAsync(user);
            await _databaseService.SaveChangesAsync();

            return user;
        }
    }
}
