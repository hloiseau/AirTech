using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
                final.Add(ConvertToEndPoint(ConvertToBuisness(c)));
            }
            return final;
        }

        //public async Task<Business.Client> CreateUser(Models.Client user)
        //{
        //    await _AirTechContext.Client.AddAsync(user);
        //    await _AirTechContext.SaveChangesAsync();

        //    return user;
        //}

        private Business.Client ConvertToBuisness(Models.Client model)
        {
            return new Business.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }

        private Shared.Client ConvertToEndPoint(Business.Client model)
        {
            return new Shared.Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Id = model.Id
            };
        }
    }
}
