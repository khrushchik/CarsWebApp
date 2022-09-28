namespace CarsWebApp.Domains
{
    public class CarDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Color { get; set; }
        public int? Year { get; set; }
        public int? DealerId { get; set; }
        public string Transmission { get; set; }
        public string Info { get; set; }
        public string Photo { get; set; }
    }
}
