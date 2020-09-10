using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VoyagerController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly VoyagerDAO _dao;

        public VoyagerController(VoyagerDAO context, ILogger<VoyagerController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        /// <summary>
        /// Returns a lsit of all Travlers
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTravlers")]
        public IEnumerable<Shared.Voyager> GetTravlers()
        {
            try
            {
                return _dao.GetVoyagers();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Returns the Travler coresponding to the given ID
        /// </summary>
        /// <param name="id">whanted travler ID</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTravlersById")]
        public Shared.Voyager GetVoyagerById(int id)
        {
            try
            {
                return _dao.GetVoyagerById(id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        [HttpPost]
        public async Task<Shared.Voyager> AddVoyager([FromBody] Shared.Voyager voyager)
        {
            return await _dao.CreateVoyagerAsync(voyager);
        }
    }
}
