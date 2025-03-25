using Microsoft.EntityFrameworkCore;
using PackagingAutomation.Models.Entities;

namespace PackagingAutomation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<FormatTube> FormatTubes { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<PackagingMachine> PackagingMachines { get; set; }
        public DbSet<ProductionSchedule> ProductionSchedules { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
    }
}
