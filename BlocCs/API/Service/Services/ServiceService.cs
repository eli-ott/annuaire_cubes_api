using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Mappers;
using BlocCs.API.Service.Models;
using BlocCs.API.Service.Repositories;

namespace BlocCs.API.Service.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<List<ServiceModel>> GetAllServicesAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    public async Task<ServiceModel?> GetServiceByIdAsync(int id)
    {
        return await _serviceRepository.FindAsync(id);
    }

    public async Task<ServiceModel> CreateServiceAsync(CreateServiceDto serviceDto)
    {
        var service = CreateServiceMapper.FromCreateServiceDto(serviceDto);
        return await _serviceRepository.AddAsync(service);
    }

    public async Task<ServiceModel> UpdateServiceAsync(ServiceModel serviceModel)
    {
        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == serviceModel.Id);
        if (!serviceCheck) throw new KeyNotFoundException();

        return await _serviceRepository.UpdateAsync(serviceModel);
    }

    public async Task<int> DeleteServiceAsync(ServiceModel serviceModel)
    {
        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == serviceModel.Id);
        if (!serviceCheck) throw new KeyNotFoundException();

        return await _serviceRepository.DeleteAsync(serviceModel);
    }
}