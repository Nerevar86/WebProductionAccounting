using Microsoft.EntityFrameworkCore;
using WebProductionAccounting.Domain.Entities;

namespace WebProductionAccounting.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
         //Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Job> Jobs { get; set; }    
    }
}
