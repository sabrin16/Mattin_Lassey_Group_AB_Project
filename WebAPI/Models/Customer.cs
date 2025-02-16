using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public virtual List<Project> Projects { get; set; } = new();
    public virtual List<ContactPerson> ContactPeople { get; } = new();
}