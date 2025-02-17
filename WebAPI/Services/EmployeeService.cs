using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ProjectDBContext _dbContext;

        public EmployeeService(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddProjectToEmployeeProjects(int employeeId, int projectId)
        {
            var employee = await _dbContext.Employees.Include(e => e.Projects)
                                               .FirstOrDefaultAsync(e => e.Id == employeeId);
            var project = await _dbContext.Projects.FindAsync(projectId);

            if (employee != null && project != null)
            {
                employee.Projects.Add(project);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                RoleName = employeeDTO.RoleName,

            };

            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return new EmployeeDTO(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees.Select(employee => new EmployeeDTO(employee)).ToList();
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                EmployeeDTO customerDTO = new EmployeeDTO(employee);
                return customerDTO;
            }
            return null;
        }

        public async Task<bool> RemoveProjectFromEmployeeProjects(int employeeId, int projectId)
        {
            var employee = await _dbContext.Employees.Include(e => e.Projects)
                                               .FirstOrDefaultAsync(e => e.Id == employeeId);
            var project = await _dbContext.Projects.FindAsync(projectId);

            if (employee != null && project != null)
            {
                employee.Projects.Remove(project);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<EmployeeDTO?> UpdateEmployeeAsync(int employeeId, EmployeeDTO employeeDTO)
        {
            var currentEmployee = await _dbContext.Employees.FindAsync(employeeId);
            if (currentEmployee != null)
            {
                currentEmployee.FirstName = employeeDTO.FirstName;
                currentEmployee.LastName = employeeDTO.LastName;
                currentEmployee.RoleName = employeeDTO.RoleName;
                await _dbContext.SaveChangesAsync();
                return new EmployeeDTO(currentEmployee);
            }
            return null;
        }
    }
}


