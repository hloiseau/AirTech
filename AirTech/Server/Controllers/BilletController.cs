using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        /// <summary>
        /// Returns a list of all Tikets
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTikets")]
        public IEnumerable<Shared.Billet> GetTikets()
        {
            return _dao.GetBillets();
        }

        //[y'shtola]
        //public async Task<Business.Billet> Create(Billet billet)
        //{
        //    return await  _dao.CreateBillet(billet);
        //}

    }
}
