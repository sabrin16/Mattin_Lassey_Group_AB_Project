using WebAPI.DTOs;


namespace WebAPI.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetAllCustomersAsync();
    Task<CustomerDTO?> GetCustomerByIdAsync(int customerId);
    Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customer);
    Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO);
    Task<bool> DeleteCustomerAsync(int customerId);
    Task<bool> AddProjectToCustomerProjectsAsync(int customerId, int projectId);
    Task<bool> RemoveProjectFromCustomerProjectsAsync(int customerId, int projectId);
}
