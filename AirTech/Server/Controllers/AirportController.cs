using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AirportDAO _dao;

        public AirportController(AirportDAO context, ILogger<AirportController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<Shared.Airport> Get()
        {
            return _dao.GetAirports();
        }
    }
}
