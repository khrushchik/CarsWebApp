using System.Collections.Generic;

namespace CarsWebApp.Domains
{
    public class ProducerDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Info { get; set; }
        public virtual ICollection<DealerDomain> Dealers { get; set; }

    }
}
