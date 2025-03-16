using System.Text.Json;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Mappers;
using BlocCs.API.Service.Models;
using BlocCs.API.Service.Repositories;

namespace BlocCs.API.Service.Services;

/// <summary>
/// The service for the services
/// </summary>
public class ServiceService : IServiceService
{
    /// <summary>
    /// The service repository
    /// </summary>
    private readonly IServiceRepository _serviceRepository;
    /// <summary>
    /// The salarie repository
    /// </summary>
    private readonly ISalarieRepository _salarieRepository;

    /// <summary>
    /// The service constructor
    /// </summary>
    /// <param name="serviceRepository">The service repository</param>
    /// <param name="salarieRepository">The salarie repository</param>
    public ServiceService(IServiceRepository serviceRepository, ISalarieRepository salarieRepository)
    {
        _serviceRepository = serviceRepository;
        _salarieRepository = salarieRepository;
    }

    /// <summary>
    /// Get all the services
    /// </summary>
    /// <returns>A tasked list of <see cref="ServiceModel"/></returns>
    public async Task<List<ServiceModel>> GetAllServicesAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    /// <summary>
    /// Get a service by its id
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>An task of <see cref="ServiceModel"/></returns>
    public async Task<ServiceModel?> GetServiceByIdAsync(int id)
    {
        return await _serviceRepository.FindAsync(id);
    }

    /// <summary>
    /// Create a new service
    /// </summary>
    /// <param name="serviceDto">An instance of <see cref="CreateServiceDto"/></param>
    /// <returns>A task of <see cref="ServiceModel"/></returns>
    public async Task<ServiceModel> CreateServiceAsync(CreateServiceDto serviceDto)
    {
        var service = CreateServiceMapper.FromCreateServiceDto(serviceDto);
        return await _serviceRepository.AddAsync(service);
    }

    /// <summary>
    /// Update a service
    /// </summary>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <returns>A task of <see cref="ServiceModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<ServiceModel> UpdateServiceAsync(ServiceModel serviceModel)
    {
        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == serviceModel.Id);
        if (!serviceCheck) throw new KeyNotFoundException();

        return await _serviceRepository.UpdateAsync(serviceModel);
    }

    /// <summary>
    /// Delete a service
    /// </summary>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <returns>A task of <see cref="int"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
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