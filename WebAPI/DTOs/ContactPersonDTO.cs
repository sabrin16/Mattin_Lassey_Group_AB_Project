using WebAPI.Models;
namespace WebAPI.DTOs;


public class ContactPersonDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public ContactPersonDTO(ContactPerson contactPeson)
    {
        Id = contactPeson.Id;
        FirstName = contactPeson.FirstName;
        LastName = contactPeson.LastName;
        Email = contactPeson.Email;
        PhoneNumber = contactPeson.PhoneNumber;
    }

}
