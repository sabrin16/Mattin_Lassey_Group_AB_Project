using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
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
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer != null) { 
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsynce(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomersWithProjectsAsync()
        {
            return await _dbContext.Customers.Include(x => x.Projects).ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            var currentCustomer = await _dbContext.Customers.FindAsync(id);
            if (currentCustomer != null) { 
                currentCustomer.Name = customer.Name;
                currentCustomer.Email = customer.Email;
                currentCustomer.PhoneNumber = customer.PhoneNumber;
                await _dbContext.SaveChangesAsync();
            }
            return currentCustomer;
        }

        
    }
}
