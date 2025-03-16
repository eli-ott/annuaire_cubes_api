using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Mappers;
using BlocCs.API.Site.Models;
using BlocCs.API.Site.Services;
using BlocCs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Site;

[ApiController]
[Route("site")]
public class SiteController : ControllerBase
{
    /// <summary>
    /// The site service
    /// </summary>
    private readonly ISiteService _siteService;

    /// <summary>
    /// The site controller constructor
    /// </summary>
    /// <param name="siteService">The site service</param>
    public SiteController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    /// <summary>
    /// Get all endpoint
    /// </summary>
    /// <returns>A tasked action result of a list of <see cref="SiteModel"/></returns>
    [HttpGet]
    public async Task<ActionResult<List<SiteModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _siteService.GetAllSitesAsync()));
    }

    /// <summary>
    /// Get by id endpoint
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>An tasked action result of <see cref="SiteModel"/></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SiteModel?>> Get(int id)
    {
        var site = await _siteService.GetSiteByIdAsync(id);

        if (site == null) return NotFound();

        return Ok(Utils.RespondWithData(site));
    }

    /// <summary>
    /// Post endpoint
    /// </summary>
    /// <param name="createSiteDto">An instance of <see cref="CreateSiteDto"/></param>
    /// <returns>A tasked action result of <see cref="SiteModel"/></returns>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SiteModel>> Post([FromBody] CreateSiteDto createSiteDto)
    {
        return Ok(Utils.RespondWithData(await _siteService.CreateSiteAsync(createSiteDto)));
    }

    /// <summary>
    /// Put endpoint
    /// </summary>
    /// <param name="updateSiteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>A tasked action result of <see cref="SiteModel"/></returns>
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<SiteModel>> Put([FromBody] UpdateDeleteSiteDto updateSiteDto)
    {
        return Ok(Utils.RespondWithData(await _siteService.UpdateSiteAsync(updateSiteDto)));
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
        var siteDto = await _siteService.GetSiteByIdAsync(id);

        if (siteDto == null) throw new KeyNotFoundException();

        var site = UpdateDeleteSiteMapper.ToUpdateDeleteSiteDto(siteDto!);

        await _siteService.DeleteSiteAsync(site);
        return Ok(Utils.RespondWithoutData());
    }
}