using AirTech.Server.Models;
using Microsoft.Extensions.Logging;
using System;
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
        
        public Shared.Order PushOrder(Shared.Order order)
        {
            throw new NotImplementedException();
            //je sais pas comment ajouter dans bdd lol 
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
    }
}
