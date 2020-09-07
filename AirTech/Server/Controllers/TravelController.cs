using AirTech.Server.DAO;
using AirTech.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : ControllerBase
    {
        private readonly ILogger<TravelController> logger;
        private readonly TravelDAO _dao;

        public TravelController(ILogger<TravelController> logger)
        {
            this.logger = logger;
            this._dao = new TravelDAO();
        }

        [HttpGet]
        public IEnumerable<Travel> Get()
        {
            return _dao.GetTravels();
        }
    }
}
