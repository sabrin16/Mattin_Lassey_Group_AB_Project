using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Project
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateOnly startDate { get; set; }
    [Required]
    public DateOnly endDate { get; set; }
    [Required]
    [ForeignKey("StatusType")]
    public int StatusId { get; set; }
    [Required]
    [ForeignKey("Customer")]
    public int CusomerId { get; set; }
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    [Required]
    [ForeignKey("Serivce")]
    public int ServiceId { get; set; }

    public virtual Customer? Customer{  get; set; }
    public virtual Employee? Employee{ get; set; }
    public virtual Service? Service{ get; set; }
    public virtual StatusType? StatusType { get; set; }

}
