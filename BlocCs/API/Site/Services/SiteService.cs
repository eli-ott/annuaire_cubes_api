using System.Text.Json;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Mappers;
using BlocCs.API.Site.Models;
using BlocCs.API.Site.Repositories;

namespace BlocCs.API.Site.Services;

/// <summary>
/// The sites service
/// </summary>
public class SiteService : ISiteService
{
    /// <summary>
    /// The site repository
    /// </summary>
    private readonly ISiteRepository _siteRepository;
    /// <summary>
    /// The salarie repository
    /// </summary>
    private readonly ISalarieRepository _salarieRepository;

    /// <summary>
    /// The site service constructor
    /// </summary>
    /// <param name="siteRepository">The site repository</param>
    /// <param name="salarieRepository">The salarie repository</param>
    public SiteService(ISiteRepository siteRepository, ISalarieRepository salarieRepository)
    {
        _siteRepository = siteRepository;
        _salarieRepository = salarieRepository;
    }

    /// <summary>
    /// Get all the sites
    /// </summary>
    /// <returns>A tasked list of <see cref="SiteModel"/></returns>
    public async Task<List<SiteModel>> GetAllSitesAsync()
    {
        return await _siteRepository.ListAsync();
    }

    /// <summary>
    /// Get a site by its id
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    public async Task<SiteModel?> GetSiteByIdAsync(int id)
    {
        return await _siteRepository.FindAsync(id);
    }

    /// <summary>
    /// Create a new site
    /// </summary>
    /// <param name="createSiteDto">An instance of <see cref="CreateSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    public async Task<SiteModel> CreateSiteAsync(CreateSiteDto createSiteDto)
    {
        var site = CreateSiteMapper.FromCreateSiteDto(createSiteDto);
        return await _siteRepository.AddAsync(site);
    }

    /// <summary>
    /// Update a site
    /// </summary>
    /// <param name="siteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<SiteModel> UpdateSiteAsync(UpdateDeleteSiteDto siteDto)
    {
        var site = UpdateDeleteSiteMapper.FromUpdateDeleteSiteDto(siteDto);
        // Will throw an error if the element doesn't exist
        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == site.Id);
        if (!siteCheck) throw new KeyNotFoundException();

        return await _siteRepository.UpdateAsync(site);
    }

    /// <summary>
    /// Delete a site
    /// </summary>
    /// <param name="siteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<SiteModel> DeleteSiteAsync(UpdateDeleteSiteDto siteDto)
    {
        var site = UpdateDeleteSiteMapper.FromUpdateDeleteSiteDto(siteDto);

        var employeesWithSite = await _salarieRepository.ListAsync(s => s.Site == site.Id);
        if (employeesWithSite.Count > 0)
            throw new BadHttpRequestException("Impossible de supprimer un site contenant des employés");

        // Will throw an error if the element doesn't exist
        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == site.Id);
        if (!siteCheck) throw new KeyNotFoundException();

        await _siteRepository.DeleteAsync(site);
        return site;
    }
}