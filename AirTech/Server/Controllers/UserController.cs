using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AirTech.Shared;
using AirTech.Server.DAO;
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

        [HttpGet]
        public IEnumerable<Shared.Client> Get()
        {
            return _dao.GetUsers();
        }

        [HttpPost]
        public async Task<Shared.Client> Create([FromBody] Shared.Client user)
        {
            return await _dao.CreateUser(user);
        }
    }
}
