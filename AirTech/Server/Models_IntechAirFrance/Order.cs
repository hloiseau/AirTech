﻿using System;
using System.Collections.Generic;

namespace AirTech.Server.Models_IntechAirFrance
{
    public partial class Order
    {
        public Order()
        {
        }

        public int? noClient { get; set; }
        public int? dateCreation { get; set; }
    }
}
