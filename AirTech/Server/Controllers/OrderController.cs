﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IEnumerable<Business.Order> Get()
        {
            return _dao.GetOrders();
        }
    }
}