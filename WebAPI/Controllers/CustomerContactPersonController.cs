using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactPersonController : ControllerBase
    {
        private readonly ICustomerContactPersonService _customerContactPersonService;
        public CustomerContactPersonController(ICustomerContactPersonService customerContactPersonService)
        {
            _customerContactPersonService = customerContactPersonService;
        }

        [HttpGet("{customerId}/contacts")]
        public async Task<ActionResult<List<ContactPersonDTO>>> GetContactPersonsByCustomerId(int customerId)
        {
            try
            {
                var contactPersons = _customerContactPersonService.GetContactPersonsByCustomerIdAsync(customerId);
                if (contactPersons == null)
                {
                    return NotFound($"No contact persons found for customer with ID {customerId}");
                }
                return Ok(contactPersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{contactPersonId}/customers")]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomersByContactPersonId(int contactPersonId)
        {
            try
            {
                var customers = await _customerContactPersonService.GetCustomersByContactPersonIdAsync(contactPersonId);
                if (customers == null)
                {
                    return NotFound($"No customers found for contact person with ID {contactPersonId}");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("customer/{customerId}/addContact/{contactPersonId}")]
        public async Task<ActionResult<bool>> AddContactPersonToCustomer(int customerId, int contactPersonId)
        {
            try
            {
                var result = await _customerContactPersonService.AddContactPersonToCustomerAsync(customerId, contactPersonId);
                if (!result)
                {
                    return (false);
                }
                return Ok(true);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("contact/{contactPersonId}/addCustomer/{customerId}")]
        public async Task<ActionResult<bool>> AddCustomerToContactPerson(int customerId, int contactPersonId)
        {
            try
            {
                var result = await _customerContactPersonService.AddCustomerToContactPersonAsync(customerId, contactPersonId);
                if (!result)
                {
                    return (false);
                }
                return Ok(true);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("customer/{customerId}/removeContact/{contactPersonId}")]
        public async Task<ActionResult<bool>> RemoveContactPersonFromCustomer(int customerId, int contactPersonId)
        {
            try
            {
                var result = await _customerContactPersonService.RemoveContactPersonFromCustomerAsync(customerId, contactPersonId);
                if (!result)
                {
                    return (false);
                }
                return Ok(true);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("contact/{contactPersonId}/removeCustomer/{customerId}")]
        public async Task<ActionResult<bool>> RemoveCustomerFromContactPerson(int customerId, int contactPersonId)
        {
            try
            {
                var result = await _customerContactPersonService.RemoveCustomerFromContactPersonAsync(customerId, contactPersonId);
                if (!result)
                {
                    return (false);
                }
                return Ok(true);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}