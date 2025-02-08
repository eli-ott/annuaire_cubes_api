using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Mappers;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Salarie.Services;
using BlocCs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Salarie;

[ApiController]
[Route("salarie")]
public class SalarieController : ControllerBase
{
    private readonly ISalarieService _salarieService;

    public SalarieController(ISalarieService salarieService)
    {
        _salarieService = salarieService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SalarieModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _salarieService.GetAllSalariesAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetSalarieDto>> Get(int id)
    {
        var salarie = await _salarieService.GetSalarieByIdAsync(id);
        if (salarie == null) return NotFound();

        return Ok(Utils.RespondWithData(salarie));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<GetSalarieDto>> Post(GetSalarieDto salarieDto)
    {
        return Ok(Utils.RespondWithData(await _salarieService.CreateSalarieAsync(salarieDto)));
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Put(GetSalarieDto salarieDto)
    {
        return Ok(Utils.RespondWithData(await _salarieService.UpdateSalarieAsync(salarieDto)));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        var salarie = GetSalarieMapper.FromGetSalarieDto(await _salarieService.GetSalarieByIdAsync(id)
                                                      ?? throw new KeyNotFoundException("Can't find the employee"));

        await _salarieService.DeleteSalarieAsync(salarie);
        return Ok(Utils.RespondWithoutData());
    }
}