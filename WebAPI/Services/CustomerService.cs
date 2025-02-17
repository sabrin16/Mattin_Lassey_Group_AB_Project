using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ProjectDBContext _dbContext;

        public CustomerService(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProjectToCustomerProjectsAsync(int customerId, int projectId)
        {
            var customer = await _dbContext.Customers.Include(c => c.Projects)
                                               .FirstOrDefaultAsync(c => c.Id == customerId);
            var project = await _dbContext.Projects.FindAsync(projectId);

            if (customer != null && project != null)
            {
                if (!customer.Projects.Any(p => p.Id.Equals(projectId)))
                {
                    customer.Projects.Add(project);

                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;

        }

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            Customer customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                PhoneNumber = customerDTO.PhoneNumber,

            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return new CustomerDTO(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers.Select(customer => new CustomerDTO(customer)).ToList();
        }

        public async Task<CustomerDTO?> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer != null)
            {
                CustomerDTO customerDTO = new CustomerDTO(customer);
                return customerDTO;
            }
            return (null);
        }

        public async Task<bool> RemoveProjectFromCustomerProjectsAsync(int customerId, int projectId)
        {
            var customer = await _dbContext.Customers.Include(c => c.Projects)
                                               .FirstOrDefaultAsync(c => c.Id == customerId);
            var project = await _dbContext.Projects.FindAsync(projectId);

            if (customer != null && project != null)
            {
                customer.Projects.Remove(project);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CustomerDTO?> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO)
        {
            var currentCustomer = await _dbContext.Customers.FindAsync(customerId);
            if (currentCustomer != null)
            {
                currentCustomer.Name = customerDTO.Name;
                currentCustomer.Email = customerDTO.Email;
                currentCustomer.PhoneNumber = customerDTO.PhoneNumber;
                await _dbContext.SaveChangesAsync();
                return customerDTO;
            }
            return null;
        }
    }
}
