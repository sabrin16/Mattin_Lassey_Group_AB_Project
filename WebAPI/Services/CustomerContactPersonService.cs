//using WebAPI.Data;
//using WebAPI.DTOs;
//using WebAPI.Interfaces;
//namespace WebAPI.Services;

//public class CustomerContactPersonService : ICustomerContactPersonService
//{
//    private readonly ProjectDBContext _dbContext;

//    public CustomerContactPersonService(ProjectDBContext dbContext)
//    {
//        _dbContext = dbContext;
//    }
//    public Task<bool> AddContactPersonToCustomerAsync(int customerId, int contactPersonId)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> AddCustomerToContactPersonAsync(int customerId, int contactPersonId)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<List<ContactPersonDTO>> GetContactPersonsByCustomerIdAsync(int customerId)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<List<CustomerDTO>> GetCustomersByContactPersonIdAsync(int contactPersonId)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> RemoveContactPersonFromCustomerAsync(int customerId, int contactPersonId)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> RemoveCustomerFromContactPersonAsync(int customerId, int contactPersonId)
//    {
//        throw new NotImplementedException();
//    }
//}
