using WebAPI.DTOs;

namespace WebAPI.Interfaces;

public interface IServiceService
{
    Task<List<ServiceDTO>> GetAllServicesAsync();
    Task<ServiceDTO?> GetServiceByIdAsync(int serviceId);
    Task<ServiceDTO> CreateServiceAsync(ServiceDTO serviceDTO);
    Task<ServiceDTO?> UpdateServiceAsync(int serviceId, ServiceDTO serviceDTO);
    Task<bool> DeleteServiceAsync(int serviceId);
}
