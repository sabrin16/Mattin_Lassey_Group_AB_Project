using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ProjectDBContext _dbContext;

        public ServiceService(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceDTO> CreateServiceAsync(ServiceDTO serviceDTO)
        {
            Service service = new Service
            {
                ServiceName = serviceDTO.ServiceName,
                Price = serviceDTO.Price,
                CurrencyName = serviceDTO.CurrencyName,
                UnitName = serviceDTO.UnitName,

            };

            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();
            return serviceDTO;
        }

        public async Task<bool> DeleteServiceAsync(int serviceId)
        {
            var service = await _dbContext.Services.FindAsync(serviceId);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ServiceDTO>> GetAllServicesAsync()
        {
            var services = await _dbContext.Services.ToListAsync();
            return services.Select(service => new ServiceDTO(service)).ToList();
        }

        public async Task<ServiceDTO?> GetServiceByIdAsync(int serviceId)
        {
            var service = await _dbContext.Services.FindAsync(serviceId);
            if (service != null)
            {
                ServiceDTO serviceDTO = new ServiceDTO(service);
                return serviceDTO;
            }
            return (null);
        }

        public async Task<ServiceDTO?> UpdateServiceAsync(int serviceId, ServiceDTO serviceDTO)
        {
            var currentService = await _dbContext.Services.FindAsync(serviceId);
            if (currentService != null)
            {
                currentService.ServiceName = currentService.ServiceName;
                currentService.Price = currentService.Price;
                currentService.UnitName = currentService.UnitName;
                currentService.CurrencyName = currentService.CurrencyName;

                await _dbContext.SaveChangesAsync();
                return serviceDTO;
            }
            return null;

        }
    }
}
