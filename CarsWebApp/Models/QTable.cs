using System;
using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Models
{
    public class QTable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual WTable WTable{ get; set; }
        [Required]
        public Guid WTableId { get; set; }
    }
}
