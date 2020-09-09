using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IEnumerable<Shared.Client> Get()
        {
            return _dao.GetUsers();
        }

        /// <summary>
        /// Returns a Client coresponding to the given ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUsersById")]
        public Shared.Client GetUsersById(int id)
        {
            return _dao.GetUsersById(id);
        }

        /// <summary>
        /// Creates a new Client and returns it.
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns></returns>
        [HttpPost(Name = "AddUser")]
        public async Task<Shared.Client> AddUser([FromBody] Shared.Client user)
        {
            return await _dao.CreateUser(user);
        }
    }
}
