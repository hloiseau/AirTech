using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirTech.Server.Models;
using Microsoft.Extensions.Logging;

namespace AirTech.Server.DAO
{
    public class ClientDAO
    {
        private AirTechContext _AirTechContext;

        public ClientDAO(AirTechContext context, ILogger<ClientDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Business.Client> GetUsers()
        {
            List<Business.Client> final = new List<Business.Client>();
            List<Models.Client> Clients = _AirTechContext.Client.ToList();
            foreach (Models.Client a in Clients)
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

        //public async Task<Business.Client> CreateUser(Models.Client user)
        //{
        //    await _AirTechContext.Client.AddAsync(user);
        //    await _AirTechContext.SaveChangesAsync();

        //    return user;
        //}
    }
}
