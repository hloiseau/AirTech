using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BilletController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly BilletDAO _dao;

        public BilletController(BilletDAO context, ILogger<BilletController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<Business.Billet> Get()
        {
            return _dao.GetBillets();
        }

        //[HttpPost]
        //public async Task<Business.Billet> Create(Billet billet)
        //{
        //    return await  _dao.CreateBillet(billet);
        //}

    }
}
