using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Models;

public class ContactPerson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<Customer> Customers { get; } = [];
    public List<CustomerContactPerson> customerContactPeople { get; } = [];
}


