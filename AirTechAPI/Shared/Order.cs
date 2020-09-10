using System;
using System.Collections.Generic;

namespace AirTechAPI.Shared
{
    public partial class Order
    {
        public Order()
        {
            Billet = new HashSet<Billet>();
        }

        public int Id { get; set; }
        public int? TotalAmount { get; set; }
        public int? CilentId { get; set; }
        public int? Luggage { get; set; }

        public virtual Client Cilent { get; set; }
        public virtual ICollection<Billet> Billet { get; set; }
    }
}
