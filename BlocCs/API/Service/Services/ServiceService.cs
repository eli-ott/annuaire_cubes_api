using System.Text.Json;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Mappers;
using BlocCs.API.Service.Models;
using BlocCs.API.Service.Repositories;

namespace BlocCs.API.Service.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ISalarieRepository _salarieRepository;

    public ServiceService(IServiceRepository serviceRepository, ISalarieRepository salarieRepository)
    {
        _serviceRepository = serviceRepository;
        _salarieRepository = salarieRepository;
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
        Console.WriteLine("Calling the delete service");
        var employeesWithService = await _salarieRepository.ListAsync(s => s.Service == serviceModel.Id);
        Console.WriteLine("logging");
        Console.WriteLine(JsonSerializer.Serialize(employeesWithService));
        if (employeesWithService.Count > 0)
            throw new BadHttpRequestException("Impossible de supprimer un service contenant des employés");

        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == serviceModel.Id);
        if (!serviceCheck) throw new KeyNotFoundException();

        return await _serviceRepository.DeleteAsync(serviceModel);
    }
}