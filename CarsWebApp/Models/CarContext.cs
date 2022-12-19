using Microsoft.EntityFrameworkCore;

namespace CarsWebApp.Models
{
    public class CarContext : DbContext
    {
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<GuidEntity> GuidEntities {get; set;}
        public virtual DbSet<Qwerty> Qwerties { get; set; }
        public virtual DbSet<WTable> WTables { get; set; }
        public virtual DbSet<QTable> QTables { get; set; }
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().Property(i => i.Id).HasColumnType("newid()");
        }
    }
}
