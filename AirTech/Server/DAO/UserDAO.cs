using System;
using System.Collections.Generic;
using AirTech.Server.Service;
using AirTech.Shared;
using Microsoft.Extensions.Logging;

namespace AirTech.Server.DAO
{
    public class UserDAO
    {
        private object _databaseService;

        public UserDAO(DatabaseService context, ILogger<UserDAO> logger)
        {
            this._databaseService = context;
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
