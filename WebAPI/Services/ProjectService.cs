//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic;
//using WebAPI.Data;
//using WebAPI.DTOs;
//using WebAPI.Interfaces;
//using WebAPI.Models;

//namespace WebAPI.Services
//{
//    public class ProjectService : IProjectService
//    {
//        private readonly ProjectDBContext _dbContext;

//        public ProjectService(ProjectDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<Project> CreateProjectAsync(Project project)
//        {
//            _dbContext.Projects.Add(project);
//            await _dbContext.SaveChangesAsync();
//            return project;
//        }

//        public Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDTO)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task DeleteProjectAsync(int id)
//        {
//            var project = await _dbContext.Projects.FindAsync(id);
//            if (project != null)
//            {
//                _dbContext.Projects.Remove(project);
//                await _dbContext.SaveChangesAsync();
//            }
//        }

//        public async Task<List<Project>> GetAllProjectAsync()
//        {
//            return await _dbContext.Projects.ToListAsync();
//        }

//        public async Task<Project> GetProjectByIdAsynce(int id)
//        {
//            return await _dbContext.Projects.FindAsync(id);
//        }

//        public async Task<List<Project>> GetProjectsByCustomerIdAsync(int id)
//        {
//            return await _dbContext.Projects.Where(p => p.CusomerId == id).ToListAsync();
//        }

//        public Task<List<ProjectDTO>> GetProjectsByEmployeeIdAsync(int employeeId)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<Project> UpdateProjectAsync(int id, Project project)
//        {
//            var currentProject = await _dbContext.Projects.FindAsync(id);
//            if (currentProject != null) { 
//               currentProject.Name = project.Name;
//                currentProject.CusomerId = id;
//                await _dbContext.SaveChangesAsync();
//            }
//            return currentProject;
//        }

//        public Task<ProjectDTO> UpdateProjectAsync(int id, ProjectDTO projectDTO)
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<ProjectDTO>> IProjectService.GetAllProjectAsync()
//        {
//            throw new NotImplementedException();
//        }

//        Task<ProjectDTO> IProjectService.GetProjectByIdAsynce(int projectId)
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<ProjectDTO>> IProjectService.GetProjectsByCustomerIdAsync(int CustomerId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
