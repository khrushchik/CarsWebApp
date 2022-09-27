﻿namespace CarsWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public int DealerId { get; set; }
        public string Info { get; set; }
        public string Photo { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
