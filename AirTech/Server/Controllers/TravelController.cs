using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : Controller
    {
        private readonly ILogger _logger;
        private readonly TravelDAO _dao;

        public TravelController(TravelDAO context, ILogger<TravelController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<Shared.Travel> Get()
        {
            return _dao.GetTravels();
        }

        [HttpGet("{id}", Name = "GetTravelById")]
        public Shared.Travel GetTravelById(int id)
        {
            return _dao.GetTravelsById(id);
        }
    }
}
