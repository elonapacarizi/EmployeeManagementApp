using EmployeeManagementApp.Application.DTO;
using EmployeeManagementApp.Application.Interface;
using EmployeeManagementApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Presentation.Controllers
{
    [Route("api/[controller]")] //localhost:xxxx/scalar/employee
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponseDto>>> GetAll()
     => Ok(await _employeeService.GetAllAsync());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost()]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Employee>> Update(Guid id, Employee employee)
        {
            if (id != employee.Id) return BadRequest("ID mismatch.");

            var updated = await _employeeService.UpdateAsync(id, employee);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
