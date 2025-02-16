using WebAPI.DTOs;

namespace WebAPI.Interfaces;

public interface ICustomerContactPersonService
{
    Task<List<ContactPersonDTO>?> GetContactPersonsByCustomerIdAsync(int customerId);
    Task<List<CustomerDTO>?> GetCustomersByContactPersonIdAsync(int contactPersonId);
    Task<bool> AddCustomerToContactPersonAsync(int customerId, int contactPersonId);
    Task<bool> RemoveCustomerFromContactPersonAsync(int customerId, int contactPersonId);
    Task<bool> AddContactPersonToCustomerAsync(int customerId, int contactPersonId);
    Task<bool> RemoveContactPersonFromCustomerAsync(int customerId, int contactPersonId);
}
