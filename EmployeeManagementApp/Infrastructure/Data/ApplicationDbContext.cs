using Microsoft.EntityFrameworkCore;
using EmployeeManagementApp.Domain.Models;
using EmployeeManagementApp.Domain.Enums;

namespace EmployeeManagementApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EducationLevel)
                .HasConversion(
                    v => v.ToString(),                                        
                    v => (EducationLevel)Enum.Parse(typeof(EducationLevel), v) 
                )
                .HasColumnType("nvarchar(32)")  
                .IsRequired();


            base.OnModelCreating(modelBuilder); 
        }
    }
}