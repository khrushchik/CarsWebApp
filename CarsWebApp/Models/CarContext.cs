using Microsoft.EntityFrameworkCore;

namespace CarsWebApp.Models
{
    public class CarContext:DbContext
    {
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
