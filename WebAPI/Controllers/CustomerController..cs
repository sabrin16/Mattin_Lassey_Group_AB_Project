using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interfaces;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        return Ok(customers);
    }
    [HttpGet("{customerId}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomerByIdAsync(int customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);
        if (customer == null) {
            return NotFound($"There is no customer with ID: {customerId}.");
        }
        return Ok(customer);
    }
    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync( CustomerDTO customerDTO)
    {
        await _customerService.CreateCustomerAsync(customerDTO);
        return customerDTO;
    }
    [HttpPut("{customerId}")]
    public async Task<ActionResult<CustomerDTO>> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO)
    {
        var currentCustomerDTO = await _customerService.GetCustomerByIdAsync(customerId);
        if (currentCustomerDTO == null) {
            return NotFound($"There is no customer with ID: {customerId} to be updated!");
        }
        await _customerService.UpdateCustomerAsync(customerId, customerDTO);
        return customerDTO;
            
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult<bool>> DeleteCustomerAsync(int customerId)
    {
        var currentCustomerDTO = await _customerService.GetCustomerByIdAsync(customerId);
        if (currentCustomerDTO == null)
        {
            return NotFound($"There is no customer with ID: {customerId} to be deleted!");
        }
        await _customerService.DeleteCustomerAsync(customerId);
        return true;

    }

    [HttpPost("{customerId}/project/{projectId}")]
    public async Task<ActionResult<bool>> AddProjectToCustomerProjects(int customerId, int projectId)
    {
        bool result = await _customerService.AddProjectToCustomerProjectsAsync(customerId, projectId);
        return result;
    }
    [HttpPost]
    public async Task<ActionResult<bool>> RemoveProjectFromCustomerProjectsAsync(int customerId, int projectId)
    {
        bool result = await _customerService.RemoveProjectFromCustomerProjectsAsync(customerId, projectId);
        return result;
    }

}
