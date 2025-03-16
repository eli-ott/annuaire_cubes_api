using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Service.Services;

/// <summary>
/// The interface for the services' service
/// </summary>
public interface IServiceService
{
    /// <summary>
    /// Get all the services
    /// </summary>
    /// <returns>A tasked list of <see cref="ServiceModel"/></returns>
    Task<List<ServiceModel>> GetAllServicesAsync();
    /// <summary>
    /// Get a service by its id
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>An task of <see cref="ServiceModel"/></returns>
    Task<ServiceModel?> GetServiceByIdAsync(int id);
    /// <summary>
    /// Create a new service
    /// </summary>
    /// <param name="serviceDto">An instance of <see cref="CreateServiceDto"/></param>
    /// <returns>A task of <see cref="ServiceModel"/></returns>
    Task<ServiceModel> CreateServiceAsync(CreateServiceDto serviceDto);
    /// <summary>
    /// Update a service
    /// </summary>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <returns>A task of <see cref="ServiceModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<ServiceModel> UpdateServiceAsync (ServiceModel serviceModel);
    /// <summary>
    /// Delete a service
    /// </summary>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <returns>A task of <see cref="int"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<int> DeleteServiceAsync(ServiceModel serviceModel);
}