﻿using AirTech.Shared;
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

        private BilletController(BilletDAO context, ILogger<BilletController> logger)
        {
            this._logger = logger;
            this._dao = context;
        }

        [HttpGet]
        public IEnumerable<Billet> Get()
        {
            return _dao.GetBillets();
        }

        [HttpPost]
        public async Task<Billet> Create()
        {
            return _dao.CreateBillet();
        }

    }
}