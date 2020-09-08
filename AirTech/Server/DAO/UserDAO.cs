using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;

namespace AirTech.Server.DAO
{
    public class UserDAO
    {
        private DatabaseService _databaseService;

        public UserDAO(DatabaseService context, ILogger<UserDAO> logger)
        {
            this._databaseService = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _databaseService.User;
        }

        public async Task<User> CreateUser(User user)
        {
            await _databaseService.User.AddAsync(user);
            await _databaseService.SaveChangesAsync();

            return user;
        }
    }
}
