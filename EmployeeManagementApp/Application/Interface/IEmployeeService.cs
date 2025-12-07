using EmployeeManagementApp.Application.DTO;
using EmployeeManagementApp.Domain.Models;

namespace EmployeeManagementApp.Application.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllAsync();
        Task<Employee?> GetByIdAsync(Guid id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee?> UpdateAsync(Guid id, Employee employee);
        Task<bool> DeleteAsync(Guid id);
    }
}
