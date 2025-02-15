using WebAPI.DTOs;
namespace WebAPI.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDTO>> GetAllEmployeesAsync();
    Task<List<EmployeeDTO>> GetEmployeeByIdAsync(int employeeId);
    Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employeeDTO);
    Task<EmployeeDTO> UpdateEmployeeAsync(int employeeId, EmployeeDTO employeeDTO);
    Task<bool> DeleteEmployeeAsync(int employeeId);
    Task<bool> AddProjectToEmployeeProjects(int employeeId, int projectId);
    Task<bool> RemoveProjectFromEmployeeProjects(int employeeId, int projectId);
}
