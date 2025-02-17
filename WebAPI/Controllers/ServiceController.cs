using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _servicService;
        public ServiceController(IServiceService serviceService)
        {
            _servicService = serviceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ServiceDTO>>> GetAllServices()
        {
            try
            {
                var services = await _servicService.GetAllServicesAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetServiceById(int id)
        {
            try
            {
                var service = await _servicService.GetServiceByIdAsync(id);
                if (service == null)
                {
                    return NotFound($"Service with ID {id} not found!");
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> CreateService([FromBody] ServiceDTO serviceDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdService = await _servicService.CreateServiceAsync(serviceDTO);
                return createdService;

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceDTO>> UpdateService(int id, [FromBody] ServiceDTO serviceDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedService = await _servicService.UpdateServiceAsync(id, serviceDTO);
                if (updatedService == null)
                {
                    return NotFound($"Service with ID {id} not found.");
                }
                return Ok(updatedService);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult<bool>> DeleteService(int serviceId)
        {
            bool isDeleted = await _servicService.DeleteServiceAsync(serviceId);

            if (isDeleted)
            {
                return Ok(true);
            }

            return NotFound(false);
        }


    }
}