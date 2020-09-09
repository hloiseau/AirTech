using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AirTech.Server.DAO
{
    public class OrderDAO
    {
        private AirTechContext _AirTechContext;

        public OrderDAO(AirTechContext context, ILogger<OrderDAO> logger)
        {
            this._AirTechContext = context;
        }

        public IEnumerable<Business.Order> GetOrders()
        {
            List<Business.Order> final = new List<Business.Order>();
            List<Order> Orders = _AirTechContext.Order.ToList();
            foreach(Order o in Orders)
            {
                final.Add(ConvertToBusiness(o));
            }
            return final;
        }

        private Business.Order ConvertToBusiness(Models.Order model)
        {
            return new Business.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId
            };
        }

        private Shared.Order ConvertToEndPoint(Business.Order model)
        {
            return new Shared.Order
            {
                Id = model.Id,
                TotalAmount = model.TotalAmount,
                CilentId = model.CilentId
            };
        }
    }
}
