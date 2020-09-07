using AirTech.Server.Interface;
using AirTech.Shared;
using System;
using System.Collections.Generic;

namespace AirTech.Server.DAO
{
    internal class TravelDAO
    {
        IDatabaseService _databaseService;

        public TravelDAO()
        {
        }

        public TravelDAO(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        public List<Travel> GetTravels()
        {
            throw new NotImplementedException();
        }
    }
}