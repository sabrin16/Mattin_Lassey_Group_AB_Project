using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;
namespace WebAPI.Services;

public class CustomerContactPersonService : ICustomerContactPersonService
{
    private readonly ProjectDBContext _dbContext;

    public CustomerContactPersonService(ProjectDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> AddContactPersonToCustomerAsync(int customerId, int contactPersonId)
    {
        var customer = await _dbContext.Customers.Include(c => c.Projects)
                                                .FirstOrDefaultAsync(c => c.Id == customerId);
        var contactPerson = await _dbContext.ContactPeople.FindAsync(contactPersonId);

        if (customer != null && contactPerson != null)
        {
            if (!customer.ContactPeople.Any(cp => cp.Id.Equals(contactPersonId)))
            {
                customer.ContactPeople.Add(contactPerson);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }

    public async Task<bool> AddCustomerToContactPersonAsync(int customerId, int contactPersonId)
    {
        var contactPerson = await _dbContext.ContactPeople.Include(cp => cp.Customers)
                                                .FirstOrDefaultAsync(cp => cp.Id == contactPersonId);

        var customer = await _dbContext.Customers.FindAsync(customerId);

        if (customer != null && contactPerson != null)
        {
            if (!contactPerson.Customers.Any(c => c.Id.Equals(customerId)))
            {
                contactPerson.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        return false;
    }

    public async Task<List<ContactPersonDTO>?> GetContactPersonsByCustomerIdAsync(int customerId)
    {
        var customer = await _dbContext.Customers.Include(c => c.Projects)
                                                .FirstOrDefaultAsync(c => c.Id == customerId);
        if (customer != null)
        {
            return customer.ContactPeople.Select(contactPerson => new ContactPersonDTO(contactPerson)).ToList();
        }
        return null;
    }

    public async Task<List<CustomerDTO>?> GetCustomersByContactPersonIdAsync(int contactPersonId)
    {
        var contactPerson = await _dbContext.ContactPeople.Include(cp => cp.Customers)
                                                .FirstOrDefaultAsync(cp => cp.Id == contactPersonId);

        if (contactPerson != null)
        {
            return contactPerson.Customers.Select(customer => new CustomerDTO(customer)).ToList();
        }
        return null;
    }

    public async Task<bool> RemoveContactPersonFromCustomerAsync(int customerId, int contactPersonId)
    {
        var customer = await _dbContext.Customers.Include(c => c.Projects)
                                                .FirstOrDefaultAsync(c => c.Id == customerId);
        var contactPerson = await _dbContext.ContactPeople.FindAsync(contactPersonId);

        if (customer != null && contactPerson != null)
        {
            if (!customer.ContactPeople.Any(cp => cp.Id.Equals(contactPersonId)))
            {
                customer.ContactPeople.Remove(contactPerson);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }

    public async Task<bool> RemoveCustomerFromContactPersonAsync(int customerId, int contactPersonId)
    {
        var contactPerson = await _dbContext.ContactPeople.Include(cp => cp.Customers)
                                                .FirstOrDefaultAsync(cp => cp.Id == contactPersonId);

        var customer = await _dbContext.Customers.FindAsync(customerId);

        if (customer != null && contactPerson != null)
        {
            if (!contactPerson.Customers.Any(c => c.Id.Equals(customerId)))
            {
                contactPerson.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        return false;
    }
}
