using AirTech.Server.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTech.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController
    {
        private readonly ILogger _logger;
        private readonly OrderDAO _dao;

        public OrderController(OrderDAO context, ILogger<OrderController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        /// <summary>
        /// Returns a list of all Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name="GetOrders")]
        public IEnumerable<Shared.Order> GetOrders()
        {
            return _dao.GetOrders();
        }

        [HttpPost]
        public async Task<Shared.Order> AddOrder([FromBody] Shared.Order order)
        {
            return await _dao.CreateOrderAsync(order);
        }
    }
}