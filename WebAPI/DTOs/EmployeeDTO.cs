using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string RoleName { get; set; }

    public EmployeeDTO(Employee employee)
    {
        Id = employee.Id;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        RoleName = employee.RoleName;
    }
}
