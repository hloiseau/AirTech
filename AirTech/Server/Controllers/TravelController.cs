using AirTech.Server.DAO;
using AirTech.Shared;
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
        public IEnumerable<Business.Travel> Get()
        {
            return _dao.GetTravels();
        }

        [HttpGet("{id}", Name = "GetTravelById")]
        public Business.Travel GetTravelById(int id)
        {
            return _dao.GetTravelsById(id);
        }
    }
}
