using System.Collections.Generic;

namespace CarsWebApp.Models
{
    public class Dealer
    {
        public Dealer()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ProducerId { get; set; }
        public string Info { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
