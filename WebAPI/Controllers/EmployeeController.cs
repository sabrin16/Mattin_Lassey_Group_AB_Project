using WebAPI.DTOs;
using WebAPI.Interfaces;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found!");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeDTO);
                return createdEmployee;

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeDTO);
                if (updatedEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                return Ok(updatedEmployee);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int employeeId)
        {
            bool isDeleted = await _employeeService.DeleteEmployeeAsync(employeeId);

            if (isDeleted)
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpPost("{employeeId}/addProjectToEmployee/{projectId}")]
        public async Task<ActionResult<bool>> AddProjectToEmployee(int employeeId, int projectId)
        {
            try
            {
                var result = await _employeeService.AddProjectToEmployeeProjects(employeeId, projectId);
                if (!result)
                {
                    return NotFound(false);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{employeeId}/removeProjectFromEmployee/{projectId}")]
        public async Task<ActionResult<bool>> RemoveProjectFromEmployee(int employeeId, int projectId)
        {
            try
            {
                var result = await _employeeService.RemoveProjectFromEmployeeProjects(employeeId, projectId);
                if (!result)
                {
                    return NotFound(false);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}