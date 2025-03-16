using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;
using BlocCs.API.Service.Services;
using BlocCs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Service;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    /// <summary>
    /// The services' service
    /// </summary>
    private readonly IServiceService _serviceService;

    /// <summary>
    /// The service controller
    /// </summary>
    /// <param name="serviceService"></param>
    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    /// <summary>
    /// Get endpoint
    /// </summary>
    /// <returns>A tasked action result of a list of <see cref="ServiceModel"/></returns>
    [HttpGet]
    public async Task<ActionResult<List<ServiceModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _serviceService.GetAllServicesAsync()));
    }

    /// <summary>
    /// Get by id endpoint
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A tasked action result of <see cref="ServiceModel"/></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceModel>> Get(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();

        return Ok(Utils.RespondWithData(service));
    }

    /// <summary>
    /// Post endpoint
    /// </summary>
    /// <param name="serviceDto">An instance of <see cref="CreateServiceDto"/></param>
    /// <returns>A tasked action result of <see cref="ServiceModel"/></returns>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ServiceModel>> Post(CreateServiceDto serviceDto)
    {
        return Ok(Utils.RespondWithData((await _serviceService.CreateServiceAsync(serviceDto))));
    }

    /// <summary>
    /// Put endpoint
    /// </summary>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <returns>A tasked action result of <see cref="ServiceModel"/></returns>
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ServiceModel>> Put(ServiceModel serviceModel)
    {
        return Ok(Utils.RespondWithData(await _serviceService.UpdateServiceAsync(serviceModel)));
    }

    /// <summary>
    /// Delete endpoint
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A tasked action result</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);

        await _serviceService.DeleteServiceAsync(service!);
        return Ok(Utils.RespondWithoutData());
    }
}