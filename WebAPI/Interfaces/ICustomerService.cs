using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsynce(int id);
    Task<List<Customer>> GetCustomersWithProjectsAsync();
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(int id, Customer customer);
    Task DeleteCustomerAsync(int id);
}
