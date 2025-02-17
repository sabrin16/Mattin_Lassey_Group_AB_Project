using WebAPI.DTOs;


namespace WebAPI.Interfaces;

public interface IProjectService
{
    Task<List<ProjectDTO>> GetAllProjectAsync();
    Task<List<ProjectDTO>?> GetProjectsByCustomerIdAsync(int CustomerId);
    Task<List<ProjectDTO>?> GetProjectsByEmployeeIdAsync(int employeeId);
    Task<ProjectDTO?> GetProjectByIdAsync(int projectId);
    Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDTO);
    Task<ProjectDTO?> UpdateProjectAsync(int id, ProjectDTO projectDTO);
    Task<bool> DeleteProjectAsync(int projectId);
}
