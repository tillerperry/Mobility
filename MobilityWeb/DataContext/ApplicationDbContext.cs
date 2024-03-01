using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MobilityWeb.Models;

namespace MobilityWeb.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
      
        
        public  DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MobilityWeb.Models.BaseEntity>? BaseEntity { get; set; }

    }
    
 
}