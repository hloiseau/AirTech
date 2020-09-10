using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        /// <summary>
        /// Retruns a list of all Airports
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAirports")]
        public IEnumerable<Shared.Airport> GetAirports()
        {
            try
            {
                return _dao.GetAirports();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
