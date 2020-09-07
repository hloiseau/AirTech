using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AirTech.Shared;
using AirTech.Server.DAO;

namespace AirTech.Server
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserDAO _dao;

        public UserController(UserDAO context, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dao.GetUsers();
        }

        [HttpPost]
        public User Create()
        {
            return _dao.CreateUser();
        }
    }
}
