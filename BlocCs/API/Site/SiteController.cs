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
    public readonly ISiteService SiteService;

    public SiteController(ISiteService siteService)
    {
        SiteService = siteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SiteModel>>> Get()
    {
        return Ok(await SiteService.GetAllSitesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SiteModel?>> Get(int id)
    {
        var site = await SiteService.GetSiteByIdAsync(id);

        if (site == null) return NotFound();

        return Ok(site);
    }

    [HttpPost]
    public async Task<ActionResult<SiteModel>> Post([FromBody] CreateSiteDto createSiteDto)
    {
        var site = await SiteService.CreateSiteAsync(createSiteDto);

        return Ok(site);
    }

    [HttpPut]
    public async Task<ActionResult<SiteModel>> Put([FromBody] UpdateDeleteSiteDto updateSiteDto)
    {
        try
        {
            var site = await SiteService.UpdateSiteAsync(updateSiteDto);
            return Ok(site);
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
            var siteDto = await SiteService.GetSiteByIdAsync(id);
            
            var site = UpdateDeleteSiteMapper.ToUpdateDeleteSiteDto(siteDto!);
            
            await SiteService.DeleteSiteAsync(site);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}