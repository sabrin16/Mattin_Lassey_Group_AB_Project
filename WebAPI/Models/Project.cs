using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;
public enum StatusType
{
    NotStarted,
    InProgress,
    Done
}

public class Project
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    [ForeignKey("Customer")]
    public int CusomerId { get; set; }
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    [Required]
    [ForeignKey("Serivce")]
    public int ServiceId { get; set; }
    [Required]
    public required StatusType Status { get; set; }

    public virtual Customer? Customer{  get; set; }
    public virtual Employee? Employee{ get; set; }
}
