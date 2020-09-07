using System;

namespace AirTech.Shared
{
    public class Travel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
