using WebAPI.Models;

namespace WebAPI.DTOs;

public class ProjectDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
    public int StatusTypeId { get; set; }
    public int CusomerId { get; set; }
    public int EmployeeId { get; set; }
    public int ServiceId { get; set; }

    public ProjectDTO(Project project) {
        Id = project.Id;
        Name = project.Name;
        Description = project.Description;
        startDate = project.startDate;
        endDate = project.endDate;
        StatusTypeId = project.StatusTypeId;
        CusomerId = project.CusomerId;
        EmployeeId = project.EmployeeId;
        ServiceId = project.ServiceId;
    }
}
