using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonService _contactPersonService;
        public ContactPersonController(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPersonDTO>>> GetAllContactPersons()
        {
            var contactPersons = await _contactPersonService.GetAllContactPersonsAsync();

            return Ok(contactPersons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPersonDTO>> GetContactPersonById(int id)
        {
            var contactPerson = await _contactPersonService.GetContactsPersonByIdAsync(id);
            if (contactPerson == null)
            {
                return NotFound($"There is no contact person with ID: {contactPerson}.");
            }
            return Ok(contactPerson);
        }
        [HttpPost]
        public async Task<ActionResult<ContactPersonDTO>> CreateContactPerson([FromBody] ContactPersonDTO contactPersonDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdContactPerson = await _contactPersonService.CreateContactPersonAsync(contactPersonDTO);
                return createdContactPerson;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactPersonDTO>> UpdateContactPersonIdAsync(int id, ContactPersonDTO contactPersonDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedContactPerson = await _contactPersonService.UpdateContactPersonAsync(id, contactPersonDTO);
                if (updatedContactPerson == null)
                {
                    return NotFound($"Contact person with ID {id} not found.");
                }
                return Ok(updatedContactPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteContactPerson(int id)
        {
            bool isDeleted = await _contactPersonService.DeleteContactPersonAsync(id);

            if (isDeleted)
            {
                return Ok(true);
            }

            return NotFound(false);
        }





    }
}