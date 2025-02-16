using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RoleName { get; set; }

    public EmployeeDTO(Employee employee)
    {
        Id = employee.Id;
        RoleName = employee.RoleName;
        LastName = employee.LastName;
        FirstName = employee.FirstName;

    }
}
