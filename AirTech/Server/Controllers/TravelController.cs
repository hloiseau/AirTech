using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        /// Returns a list of all Travels
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTravels")]
        public IEnumerable<Shared.Travel> GetTravels()
        {
            try
            {
                return _dao.GetTravels();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Returns the Travel coresponding to the given Id
        /// </summary>
        /// <param name="id">whanted travel Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTravelById")]
        public Shared.Travel GetTravelById(int id)
        {
            try
            {
                return _dao.GetTravelsById(id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
