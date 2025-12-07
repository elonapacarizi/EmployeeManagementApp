using EmployeeManagementApp.Application.DTO;
using EmployeeManagementApp.Application.Interface;
using EmployeeManagementApp.Domain.Models;
using EmployeeManagementApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (employee == null) return false;

            employee.IsDeleted = true;
            employee.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            return await _context.Employees
                .AsNoTracking()
                .Where(e => !e.IsDeleted)
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PersonalNumber = e.PersonalNumber,
                    DateOfBirth = e.DateOfBirth,
                    Age = CalculateAge(e.DateOfBirth),
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    HireDate = e.HireDate,
                    GrossSalary = e.GrossSalary,
                    CreatedAt = e.CreatedAt
                })
                .ToListAsync();
        }




        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }


        public async Task<Employee?> UpdateAsync(Guid id, Employee employee)
        {
            var existing = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (existing == null) return null;

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.PersonalNumber = employee.PersonalNumber;
            existing.DateOfBirth = employee.DateOfBirth;
            existing.EducationLevel = employee.EducationLevel;
            existing.PhoneNumber = employee.PhoneNumber;
            existing.Email = employee.Email;
            existing.HireDate = employee.HireDate;
            existing.GrossSalary = employee.GrossSalary;

            existing.UpdatedAt = DateTime.Now;  

            await _context.SaveChangesAsync();
            return existing;
        }


        public static int CalculateAge(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }

    }
}
