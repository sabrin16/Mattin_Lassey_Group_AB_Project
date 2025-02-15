using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Models;

public class Service
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string ServiceName { get; set; }
    [Required]
    public required decimal Price { get; set; }
    [Required]
    public required string UnitName { get; set; }
    [Required]
    public required string CurrencyName { get; set; }
}
