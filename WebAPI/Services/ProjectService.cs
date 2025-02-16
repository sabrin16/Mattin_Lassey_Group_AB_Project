using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectDBContext _dbContext;

        public ProjectService(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDTO)
        {
            Project project = new Project
            {
                Name = projectDTO.Name,
                StartDate = projectDTO.StartDate,
                EndDate = projectDTO.EndDate,
                ServiceId = projectDTO.ServiceId,
                Status = projectDTO.Status,
                EmployeeId = projectDTO.EmployeeId,
                CusomerId = projectDTO.CusomerId,
            };
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return projectDTO;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ProjectDTO?> GetProjectByIdAsynce(int projectId)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            if (project != null)
            {
                ProjectDTO projectDTO = new ProjectDTO(project);
                return projectDTO;
            }
            return (null);
        }

        public async Task<List<ProjectDTO>?> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.Include(e => e.Projects)
                                               .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee != null)
            {
                return employee.Projects.Select(project => new ProjectDTO(project)).ToList();
            }
            return null;

        }

        public async Task<List<ProjectDTO>?> GetProjectsByCustomerIdAsync(int customerId)
        {
            var customer = await _dbContext.Customers.Include(c => c.Projects)
                                               .FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer != null)
            {
                return customer.Projects.Select(project => new ProjectDTO(project)).ToList();
            }
            return null;
        }

        public async Task<ProjectDTO?> UpdateProjectAsync(int projectId, ProjectDTO project)
        {
            var currentProject = await _dbContext.Projects.FindAsync(projectId);
            if (currentProject != null)
            {
                currentProject.Name = project.Name;
                currentProject.Description = project.Description;
                currentProject.StartDate = project.StartDate;
                currentProject.EndDate = project.EndDate;
                currentProject.ServiceId = project.ServiceId;
                currentProject.Status = project.Status;
                currentProject.EmployeeId = project.EmployeeId;
                currentProject.CusomerId = project.CusomerId;
                await _dbContext.SaveChangesAsync();
                return project;
            }
            return null;
        }

        public async Task<List<ProjectDTO>> GetAllProjectAsync()
        {
            var projects = await _dbContext.Projects.ToListAsync();
            return projects.Select(project => new ProjectDTO(project)).ToList();
        }
    }
}
