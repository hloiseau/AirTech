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

        /// <summary>
        /// return a list of all Travels
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTravels")]
        public IEnumerable<Shared.Travel> GetTravels()
        {
            return _dao.GetTravels();
        }

        /// <summary>
        /// Returns the Travel coresponding to the given Id
        /// </summary>
        /// <param name="id">whanted travel Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTravelById")]
        public Shared.Travel GetTravelById(int id)
        {
            return _dao.GetTravelsById(id);
        }
    }
}
