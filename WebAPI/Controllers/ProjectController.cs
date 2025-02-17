using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                if (project == null)
                {
                    return NotFound($"Project with ID {id} not found!");
                }
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("employee/{employeeId}")]

        public async Task<ActionResult<List<ProjectDTO>>> GetProjectsByEmployeeId(int employeeId)
        {
            try
            {
                var projects = await _projectService.GetProjectsByEmployeeIdAsync(employeeId);
                if (projects == null)
                {
                    return NotFound($"No projects found for employee with ID {employeeId}.");
                }
                return Ok(projects);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("customer/{customerId}")]

        public async Task<ActionResult<List<ProjectDTO>>> GetProjectsByCustomerId(int customerId)
        {
            try
            {
                var projects = await _projectService.GetProjectsByCustomerIdAsync(customerId);
                if (projects == null)
                {
                    return NotFound($"No projects found for customer with ID {customerId}.");
                }
                return Ok(projects);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdProject = await _projectService.CreateProjectAsync(projectDTO);
                return createdProject;

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectDTO>> UpdateProject(int id, [FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedProject = await _projectService.UpdateProjectAsync(id, projectDTO);
                if (updatedProject == null)
                {
                    return NotFound($"Project with ID {id} not found.");
                }
                return Ok(updatedProject);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<bool>> DeleteProject(int projectId)
        {
            bool isDeleted = await _projectService.DeleteProjectAsync(projectId);

            if (isDeleted)
            {
                return Ok(true);
            }

            return NotFound(false);
        }






    }
}



