using WebAPI.Models;
namespace WebAPI.DTOs;

public class ServiceDTO
{
    public int Id { get; set; }
    public required string ServiceName { get; set; }
    public required decimal Price { get; set; }
    public required string UnitName { get; set; }
    public required string CurrencyName { get; set; }

    public ServiceDTO (Service service)
    {
        Id = service.Id;
        ServiceName = service.ServiceName;
        Price = service.Price;
        UnitName = service.UnitName;
        CurrencyName = service.CurrencyName;
    }
}
