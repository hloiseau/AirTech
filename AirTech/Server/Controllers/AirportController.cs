using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AirTech.Shared;
using AirTech.Server.DAO;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AirportDAO _dao;

        public AirportController(AirportDAO context, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<Airport> Get()
        {
            return _dao.GetAirports();
        }
    }
}
