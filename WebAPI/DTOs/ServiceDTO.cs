using WebAPI.Models;
namespace WebAPI.DTOs;

public class ServiceDTO
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public decimal Price { get; set; }
    public string UnitName { get; set; }
    public string CurrencyName { get; set; }
    public ServiceDTO() { }
    public ServiceDTO(Service service)
    {
        Id = service.Id;
        ServiceName = service.ServiceName;
        Price = service.Price;
        UnitName = service.UnitName;
        CurrencyName = service.CurrencyName;
    }
}
