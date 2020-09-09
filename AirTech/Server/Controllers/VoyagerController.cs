using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            this ._dao = context;
        }

        [HttpGet]
        public IEnumerable<Shared.Voyager> Get()
        {
            return _dao.GetVoyager();
        }

        [HttpGet("{id}",Name ="GetVoyagerId")]
        public Shared.Voyager GetVoyagerById(int id)
        {
            return _dao.GetVoyagerById(id);
        }

        //[HttpPost]
        //public async Task<Business.Voyager> Create()
        //{

        //}
    }
}
