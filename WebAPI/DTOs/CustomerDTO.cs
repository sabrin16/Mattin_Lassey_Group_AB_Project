using WebAPI.Models;


namespace WebAPI.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public CustomerDTO(Customer customer) {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
        }
        
    }
}