using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTech.Server.DAO
{
    public class OrderDAO
    {
        private AirTechContext _AirTechContext;

        public OrderDAO(AirTechContext context, ILogger<OrderDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Shared.Order> GetOrders()
        {
            List<Shared.Order> final = new List<Shared.Order>();
            List<Order> Orders = _AirTechContext.Order.ToList();
            foreach(Order o in Orders)
            {
                final.Add(ConvertToEndPoint(ConvertToBusiness(o)));
            }
            return final;
        }
        
        public async Task<Shared.Order> CreateOrderAsync(Shared.Order order)
        {
            await _AirTechContext.Order.AddAsync(ConvertToDal(order));
            await _AirTechContext.SaveChangesAsync();

            List<Models.Order> orders = _AirTechContext.Order.OrderByDescending(t => t.Id).ToList();
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
