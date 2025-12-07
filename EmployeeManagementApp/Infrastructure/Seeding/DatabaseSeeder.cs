using EmployeeManagementApp.Domain.Enums;
using EmployeeManagementApp.Domain.Models;
using EmployeeManagementApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Infrastructure.Seeding
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            if (await db.Employees.AnyAsync()) return; 

            var employees = new List<Employee>
            {
                new Employee
             {
                Id = Guid.NewGuid(),
                FirstName = "Elona",
                LastName = "Pacarizi",
                PersonalNumber = "1241899889",
                DateOfBirth = new DateTime(2001, 8, 15),
                EducationLevel = EducationLevel.Master,
                Email = "elona@gmail.com",
                PhoneNumber = "+383 49 123 123",
                HireDate = DateTime.Now,
                GrossSalary = 1000.00m,
                CreatedAt = DateTime.Now
            },
            new Employee
             {
                Id = Guid.NewGuid(),
                FirstName = "Filan",
                LastName = "Fisteku",
                PersonalNumber = "1234567890",
                DateOfBirth = new DateTime(1995, 7, 15),
                EducationLevel = EducationLevel.Master,
                Email = "filan.fisteku@gmail.com",
                PhoneNumber = "+383 49 123 123",
                HireDate = DateTime.Now.AddMonths(-24),
                GrossSalary = 1000.00m,
                CreatedAt = DateTime.Now
            },
            };

            await db.Employees.AddRangeAsync(employees);
            await db.SaveChangesAsync();
        }
    }
}
