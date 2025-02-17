using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly ProjectDBContext _dbContext;

        public ContactPersonService(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactPersonDTO> CreateContactPersonAsync(ContactPersonDTO contactPersonDTO)
        {
            ContactPerson contactPerson = new ContactPerson
            {
                FirstName = contactPersonDTO.FirstName,
                LastName = contactPersonDTO.LastName,
                Email = contactPersonDTO.Email,
                PhoneNumber = contactPersonDTO.PhoneNumber,

            };

            _dbContext.ContactPeople.Add(contactPerson);
            await _dbContext.SaveChangesAsync();
            return new ContactPersonDTO(contactPerson);
        }

        public async Task<bool> DeleteContactPersonAsync(int contactPersonId)
        {
            var contactPerson = await _dbContext.ContactPeople.FindAsync(contactPersonId);
            if (contactPerson != null)
            {
                _dbContext.ContactPeople.Remove(contactPerson);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ContactPersonDTO>> GetAllContactPersonsAsync()
        {
            var ContactPeople = await _dbContext.ContactPeople.ToListAsync();
            return ContactPeople.Select(ContactPerson => new ContactPersonDTO(ContactPerson)).ToList();
        }

        public async Task<ContactPersonDTO?> GetContactsPersonByIdAsync(int contactPersonId)
        {
            var contactPerson = await _dbContext.ContactPeople.FindAsync(contactPersonId);
            if (contactPerson != null)
            {
                ContactPersonDTO contactPersonDTO = new ContactPersonDTO(contactPerson);
                return contactPersonDTO;
            }
            return null;
        }

        public async Task<ContactPersonDTO?> UpdateContactPersonAsync(int contactPersonId, ContactPersonDTO contactPersonDTO)
        {
            var currentContactPerson = await _dbContext.ContactPeople.FindAsync(contactPersonId);
            if (currentContactPerson != null)
            {
                currentContactPerson.FirstName = contactPersonDTO.FirstName;
                currentContactPerson.LastName = contactPersonDTO.LastName;
                currentContactPerson.Email = contactPersonDTO.Email;
                currentContactPerson.PhoneNumber = currentContactPerson.PhoneNumber;
                await _dbContext.SaveChangesAsync();
                return contactPersonDTO;
            }
            return null;
        }
    }
}
