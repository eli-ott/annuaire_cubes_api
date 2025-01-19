using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Service.Services;

public interface IServiceService
{
    Task<List<ServiceModel>> GetAllServicesAsync();
    Task<ServiceModel?> GetServiceByIdAsync(int id);
    Task<ServiceModel> CreateServiceAsync(CreateServiceDto serviceDto);
    Task<ServiceModel> UpdateServiceAsync (ServiceModel serviceModel);
    Task<int> DeleteServiceAsync(ServiceModel serviceModel);
}