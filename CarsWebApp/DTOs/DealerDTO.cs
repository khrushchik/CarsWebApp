using System.Collections.Generic;

namespace CarsWebApp.DTOs
{
    public class DealerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<CarDTO> Cars { get; set; }
    }
}
