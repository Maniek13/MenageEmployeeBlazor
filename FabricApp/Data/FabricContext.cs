using FabricAPP.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FabricAPP.Data
{
    public class FabricContext : DbContext
    {
        public FabricContext(DbContextOptions<FabricContext> options) : base(options)
        {
        }

        public FabricContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Models.Settings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne(b => b.Employee)
                .HasForeignKey<Address>(b => b.EmployeeID);
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
