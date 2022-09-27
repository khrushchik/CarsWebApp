using System.Collections.Generic;

namespace CarsWebApp.DTOs
{
    public class ProducerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Info { get; set; }
        public virtual ICollection<DealerDTO> Dealers { get; set; }
    }
}
