using System;
using System.Collections.Generic;

namespace AirTech.Business
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
