using System.Collections.Generic;

namespace CarsWebApp.Models
{
    public class Producer
    {
        public Producer()
        {
            Dealers = new List<Dealer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Dealer> Dealers { get; set; }
    }
}
