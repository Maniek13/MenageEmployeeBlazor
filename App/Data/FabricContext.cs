using FabricAPP.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FabricAPP.Data
{
	public class FabricContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RAKIETA\SQLEXPRESS;Database=FabricDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne(b => b.Employee)
                .HasForeignKey<Address>(b => b.EmployeeID);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
	}
}
