using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.DTOs;

public class ProjectDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusType Status { get; set; }
    public int CusomerId { get; set; }
    public int EmployeeId { get; set; }
    public int ServiceId { get; set; }

    public ProjectDTO(Project project) {
        Id = project.Id;
        Name = project.Name;
        Description = project.Description;
        StartDate = project.StartDate;
        EndDate = project.EndDate;
        CusomerId = project.CusomerId;
        EmployeeId = project.EmployeeId;
        ServiceId = project.ServiceId;
        Status = project.Status;
    }
}
