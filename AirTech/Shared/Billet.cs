using System;

namespace AirTech.Shared
{
    public class Billet
    {
        public int IDUser { get; set; }
        public User User { get; set; }
        public int IDTravel { get; set; }
        public Travel Travel { get; set; }
    }
}
