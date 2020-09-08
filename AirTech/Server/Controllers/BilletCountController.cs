using AirTech.Server.DAO;
using AirTech.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BilletCountController : Controller
    {
        private readonly ILogger _logger;
        private readonly BilletCountDAO _dao;

        public BilletCountController(BilletCountDAO context, ILogger<TravelController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<BilletCount> Get()
        {
            return _dao.GetBilletCounts();
        }
    }
}
