using System.Data.Entity;

namespace DAL.Models
{
    public class Context:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderUnit> OrderUnits { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
