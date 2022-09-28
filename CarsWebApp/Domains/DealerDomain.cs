using System.Collections.Generic;

namespace CarsWebApp.Domains
{
    public class DealerDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public int? ProducerId { get; set; }

        public string Icon { get; set; }

        public virtual ICollection<CarDomain> Cars { get; set; }
    }
}
