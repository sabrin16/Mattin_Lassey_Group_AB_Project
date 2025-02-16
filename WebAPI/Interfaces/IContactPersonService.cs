using WebAPI.DTOs;

namespace WebAPI.Interfaces
{
    public interface IContactPersonService
    {
        Task<List<ContactPersonDTO>> GetAllContactPersonsAsync();
        Task<ContactPersonDTO?> GetContactsPersonByIdAsync(int contactPersonId);
        Task<ContactPersonDTO> CreateContactPersonAsync(ContactPersonDTO contactPersonDTO);
        Task<ContactPersonDTO?> UpdateContactPersonAsync(int contactPersonId, ContactPersonDTO contactPersonDTO);
        Task<bool> DeleteContactPersonAsync(int contactPersonId);
    }
}
