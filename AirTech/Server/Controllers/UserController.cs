using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AirTech.Shared;
using AirTech.Server.DAO;

namespace AirTech.Server
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly UserDAO _dao;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger;
            this._dao = new UserDAO();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dao.GetUserq();
        }

        [HttpPost]
        public User Create()
        {
            return _dao.CreateUser();
        }
    }
}
