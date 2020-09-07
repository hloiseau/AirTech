using System;
using System.Collections.Generic;
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
            return _databaseService.Users;
        }

        public User CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
