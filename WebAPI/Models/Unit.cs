using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Unit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UnitName { get; set; }
}
