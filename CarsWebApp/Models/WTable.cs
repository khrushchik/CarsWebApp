using System;
using System.Collections.Generic;

namespace CarsWebApp.Models
{
    public class WTable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<QTable> QTables { get; set; } = new List<QTable>();
    }
}
