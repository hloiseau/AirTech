using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTech.Server
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly ClientDAO _dao;

        public UserController(ClientDAO context, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        /// <summary>
        /// Returns a lit of all Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<Shared.Client>> GetAsync()
        {
            try
            {
                return await _dao.GetUsers();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Returns a Client coresponding to the given ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUsersById")]
        public Shared.Client GetUsersById(int id)
        {
            try
            {
                return _dao.GetUsersById(id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Creates a new Client and returns it.
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns></returns>
        [HttpPost(Name = "AddUser")]
        public async Task<Shared.Client> AddUser([FromBody] Shared.Client user)
        {
            try
            {
                return await _dao.CreateUser(user);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
