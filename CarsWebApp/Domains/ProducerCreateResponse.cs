using CarsWebApp.DTOs;
using System.Collections.Generic;

namespace CarsWebApp.Domains
{
    public class ProducerCreateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Info { get; set; }
        public virtual ICollection<DealerDTO> Dealers { get; set; }
    }
}
