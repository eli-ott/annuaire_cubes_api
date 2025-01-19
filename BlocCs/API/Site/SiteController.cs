using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Mappers;
using BlocCs.API.Site.Models;
using BlocCs.API.Site.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Site;

[ApiController]
[Route("[controller]")]
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
        return Ok(await _siteService.GetAllSitesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SiteModel?>> Get(int id)
    {
        var site = await _siteService.GetSiteByIdAsync(id);

        if (site == null) return NotFound();

        return Ok(site);
    }

    [HttpPost]
    public async Task<ActionResult<SiteModel>> Post([FromBody] CreateSiteDto createSiteDto)
    {
        return Ok(await _siteService.CreateSiteAsync(createSiteDto));
    }

    [HttpPut]
    public async Task<ActionResult<SiteModel>> Put([FromBody] UpdateDeleteSiteDto updateSiteDto)
    {
        try
        {
            return Ok(await _siteService.UpdateSiteAsync(updateSiteDto));
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
            var siteDto = await _siteService.GetSiteByIdAsync(id);
            
            var site = UpdateDeleteSiteMapper.ToUpdateDeleteSiteDto(siteDto!);
            
            await _siteService.DeleteSiteAsync(site);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}