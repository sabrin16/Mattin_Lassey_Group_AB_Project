using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface IProjectService
{
    Task<List<Project>> GetAllProjectAsync();
    Task<List<Project>> GetProjectsByCustomerIdAsync(int id);
    Task<Project> GetProjectByIdAsynce(int id);
    Task<Project> CreateProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(int id, Project project);
    Task DeleteProjectAsync(int id);
}
