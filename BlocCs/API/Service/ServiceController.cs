using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Mappers;
using BlocCs.API.Service.Models;
using BlocCs.API.Service.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Service;

[ApiController]
[Route("[controller]")]
public class ServiceController: ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceModel>>> Get()
    {
        return Ok(await _serviceService.GetAllServicesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceModel>> Get(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();
        
        return Ok(service);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceModel>> Post(CreateServiceDto serviceDto)
    {
        return Ok(await _serviceService.CreateServiceAsync(serviceDto));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceModel>> Put(ServiceModel serviceModel)
    {
        try
        {
            return Ok(await _serviceService.UpdateServiceAsync(serviceModel));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var service = await _serviceService.GetServiceByIdAsync(id);

            await _serviceService.DeleteServiceAsync(service!);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
}