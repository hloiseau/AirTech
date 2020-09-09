using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        /// <summary>
        /// Returns a list of all Tikets
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTikets")]
        public IEnumerable<Shared.Billet> GetTikets()
        {
            return _dao.GetBillets();
        }

        /// <summary>
        /// Returns a list of all Tikets
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTiketsById")]
        public Shared.Billet GetTiketsById(int id)
        {
            return _dao.GetBilletsById(id);
        }

        /// <summary>
        /// create a new Ticket and returns it
        /// </summary>
        /// <param name="billet"></param>
        /// <returns></returns>
        [HttpPost(Name= "CreateBillet")]
        public async Task<Shared.Billet> CreateBillet(Shared.Billet billet)
        {
            return await _dao.CreateBillet(billet);
        }
    }
}
