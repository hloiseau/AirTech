﻿using AirTechAPI.Server.Models;
using AirTechAPI.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTechAPI.Server.DAO
{
    public class OrderDAO
    {
        private AirTechAPIContext _AirTechAPIContext;
        private IntechAirFranceService _intechAirFranceService;


        public OrderDAO(AirTechAPIContext context, ILogger<OrderDAO> logger, IntechAirFranceService intechAirFranceService)
        {
            this._AirTechAPIContext = context;
            _intechAirFranceService = intechAirFranceService;
        }

        public async Task<IEnumerable<Shared.Order>> GetOrders()
        {
            List<Shared.Order> final = new List<Shared.Order>();
            List<Order> Orders = _AirTechAPIContext.Order.Include(x => x.Cilent).Include(x => x.Billet).ToList();
            List<Models_IntechAirFrance.Order> Orders2 = await _intechAirFranceService.GetOrdersAsync();

            foreach (Order o in Orders)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(o)));
            }
            foreach (var o in Orders2)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(o)));
            }
            return final;
        }

        public async Task<Shared.Order> CreateOrderAsync(Shared.Order order)
        {
            await _AirTechAPIContext.Order.AddAsync(ConvertToDal(order));
            await _AirTechAPIContext.SaveChangesAsync();

            List<Models.Order> orders = _AirTechAPIContext.Order.Include(x => x.Cilent).Include(x => x.Billet).OrderByDescending(t => t.Id).ToList();
            Models.Order final = orders.FirstOrDefault<Models.Order>();
            return ConvertToEndPoint(final);
        }

        internal Shared.Order GetOrderById(int id)
        {
            IQueryable<Models.Order> list = _AirTechAPIContext.Order.Include(x => x.Cilent).Include(x => x.Billet).Where(t => t.Id == id);
            Models.Order o = list.FirstOrDefault<Models.Order>();
            return ConvertToEndPoint(ConvertToBusiness(o));
        }

        internal async Task<Shared.Order> UpdateOrderByIdAsync(int id, Shared.Order order)
        {
            Shared.Order o = GetOrderById(id);
            _AirTechAPIContext.Order.Update(ConvertToDal(order));
            _AirTechAPIContext.SaveChangesAsync().Wait();

            List<Models.Order> orders = _AirTechAPIContext.Order.Include(x => x.Cilent).Include(x => x.Billet).OrderByDescending(t => t.Id).ToList();
            Models.Order final = orders.FirstOrDefault<Models.Order>();
            return ConvertToEndPoint(final);
        }

        public static Business.Order ConvertToBusiness(Models.Order model)
        {
            return new Business.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId,
                Cilent = ClientDAO.ConvertToBusiness(model.Cilent),
                Billet = BilletDAO.ConvertToBusiness(model.Billet)
            };
        }

        public static Business.Order ConvertToBusiness(Models_IntechAirFrance.Order model)
        {
            return new Business.Order
            {
                CilentId = model.noClient
            };
        }

        public static Shared.Order ConvertToEndPoint(Business.Order model)
        {
            return new Shared.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId,
                Cilent = ClientDAO.ConvertToEndPoint(model.Cilent),
                Billet = BilletDAO.ConvertToEndPoint(model.Billet)
            };
        }

        public static Shared.Order ConvertToEndPoint(Models.Order model)
        {
            return new Shared.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId,
                Cilent = ClientDAO.ConvertToEndPoint(model.Cilent),
                Billet = BilletDAO.ConvertToEndPoint(model.Billet)
            };
        }

        public static Models.Order ConvertToDal(Shared.Order model)
        {
            return new Models.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId,
                Cilent = ClientDAO.ConvertToDal(model.Cilent),
                Billet = BilletDAO.ConvertToDal(model.Billet)
            };
        }

        public static Models.Order ConvertToDal(Business.Order model)
        {
            return new Models.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId,
                Cilent = ClientDAO.ConvertToDal(model.Cilent),
                Billet = BilletDAO.ConvertToDal(model.Billet)
            };
        }
    }
}