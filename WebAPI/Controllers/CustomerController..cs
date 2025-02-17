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
        if (customer == null)
        {
            return NotFound($"There is no customer with ID: {customerId}.");
        }
        return Ok(customer);
    }
    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync([FromBody] CustomerDTO customerDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCustomer = await _customerService.CreateCustomerAsync(customerDTO);
            return createdCustomer;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }
    [HttpPut("{customerId}")]
    public async Task<ActionResult<CustomerDTO>> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedCustomer = await _customerService.UpdateCustomerAsync(customerId, customerDTO);
            if (updatedCustomer == null)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
            return Ok(updatedCustomer);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult<bool>> DeleteCustomer(int customerId)
    {
        bool isDeleted = await _customerService.DeleteCustomerAsync(customerId);

        if (isDeleted)
        {
            return Ok(true);
        }

        return NotFound(false);
    }

    [HttpPost("{customerId}/addProjectToCustomer/{projectId}")]
    public async Task<ActionResult<bool>> AddProjectToCustomerProjects(int customerId, int projectId)
    {
        try
        {
            var result = await _customerService.AddProjectToCustomerProjectsAsync(customerId, projectId);
            if (!result)
            {
                return NotFound(false);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpPost("{customerId}/removeProjectFromeCustomer/{projectId}")]
    public async Task<ActionResult<bool>> RemoveProjectFromCustomerProjectsAsync(int customerId, int projectId)
    {
        try
        {
            var result = await _customerService.RemoveProjectFromCustomerProjectsAsync(customerId, projectId);
            if (!result)
            {
                return NotFound(false);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
