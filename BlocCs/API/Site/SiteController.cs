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
    private readonly ISiteService _siteService;

    public SiteController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SiteModel>>> Get()
    {
        return Ok(Utils.RespondWithData(await _siteService.GetAllSitesAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SiteModel?>> Get(int id)
    {
        var site = await _siteService.GetSiteByIdAsync(id);

        if (site == null) return NotFound();

        return Ok(Utils.RespondWithData(site));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SiteModel>> Post([FromBody] CreateSiteDto createSiteDto)
    {
        return Ok(Utils.RespondWithData(await _siteService.CreateSiteAsync(createSiteDto)));
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<SiteModel>> Put([FromBody] UpdateDeleteSiteDto updateSiteDto)
    {
        return Ok(Utils.RespondWithData(await _siteService.UpdateSiteAsync(updateSiteDto)));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        var siteDto = await _siteService.GetSiteByIdAsync(id);
        
        if(siteDto == null) throw new KeyNotFoundException();

        var site = UpdateDeleteSiteMapper.ToUpdateDeleteSiteDto(siteDto!);

        await _siteService.DeleteSiteAsync(site);
        return Ok(Utils.RespondWithoutData());
    }
}