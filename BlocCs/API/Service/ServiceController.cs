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
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _serviceService.GetAllServicesAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceModel>> Get(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();

        return Ok(Utils.RespondWithData(service));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ServiceModel>> Post(CreateServiceDto serviceDto)
    {
        return Ok(Utils.RespondWithData((await _serviceService.CreateServiceAsync(serviceDto))));
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ServiceModel>> Put(ServiceModel serviceModel)
    {
        return Ok(Utils.RespondWithData(await _serviceService.UpdateServiceAsync(serviceModel)));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);

        await _serviceService.DeleteServiceAsync(service!);
        return Ok(Utils.RespondWithoutData());
    }
}