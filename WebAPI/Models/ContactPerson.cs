using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Models;

public class ContactPerson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public List<Customer> Customers { get; } = [];
}


