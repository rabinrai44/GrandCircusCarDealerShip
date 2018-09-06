using System;

namespace CarDealerShip.Domain.DomainModels
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Trim { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public int SafetyRating { get; set; }
    }
}
