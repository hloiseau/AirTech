using System;
using System.Collections.Generic;
using AirTech.Shared;
using AirTech.Server.Interface;

namespace AirTech.Server.DAO
{
    internal class UserDAO
    {
        IDatabaseService _databaseService;
        
        public UserDAO(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        public UserDAO()
        {
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
