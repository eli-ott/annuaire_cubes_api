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
    /// <summary>
    /// The salarie service
    /// </summary>
    private readonly ISalarieService _salarieService;

    /// <summary>
    /// The salarie controller
    /// </summary>
    /// <param name="salarieService">The salaries service</param>
    public SalarieController(ISalarieService salarieService)
    {
        _salarieService = salarieService;
    }

    /// <summary>
    /// Get all endpoint
    /// </summary>
    /// <returns>A tasked action result of a list of <see cref="SalarieModel"/></returns>
    [HttpGet]
    public async Task<ActionResult<List<SalarieModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _salarieService.GetAllSalariesAsync()));
    }

    /// <summary>
    /// Get by id endpoint
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A tasked action result of <see cref="GetSalarieDto"/></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetSalarieDto>> Get(int id)
    {
        var salarie = await _salarieService.GetSalarieByIdAsync(id);
        if (salarie == null) return NotFound();

        return Ok(Utils.RespondWithData(salarie));
    }

    /// <summary>
    /// Post endpoint
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A tasked action result of <see cref="GetSalarieDto"/></returns>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<GetSalarieDto>> Post(GetSalarieDto salarieDto)
    {
        return Ok(Utils.RespondWithData(await _salarieService.CreateSalarieAsync(salarieDto)));
    }

    /// <summary>
    /// Put endpoint
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A tasked action result of <see cref="GetSalarieDto"/></returns>
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<GetSalarieDto>> Put(GetSalarieDto salarieDto)
    {
        return Ok(Utils.RespondWithData(await _salarieService.UpdateSalarieAsync(salarieDto)));
    }

    /// <summary>
    /// Delete endpoint
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A tasked action result</returns>
    /// <exception cref="KeyNotFoundException"></exception>
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