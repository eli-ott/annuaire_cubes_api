using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Mappers;
using BlocCs.API.Site.Models;
using BlocCs.API.Site.Repositories;
using BlocCs.API.Site.Services;


public class SiteService : ISiteService
{
    private readonly ISiteRepository _siteRepository;

    public SiteService(ISiteRepository siteRepository)
    {
        _siteRepository = siteRepository;
    }

    public async Task<List<SiteModel>> GetAllSitesAsync()
    {
        return await _siteRepository.ListAsync();
    }

    public async Task<SiteModel?> GetSiteByIdAsync(int id)
    {
        return await _siteRepository.FindAsync(id);
    }

    public async Task<SiteModel> CreateSiteAsync(CreateSiteDto createSiteDto)
    {
        var site = CreateSiteMapper.FromCreateSiteDto(createSiteDto);
        return await _siteRepository.AddAsync(site);
    }

    public async Task<SiteModel> UpdateSiteAsync(UpdateDeleteSiteDto siteDto)
    {
        var site = UpdateDeleteSiteMapper.FromUpdateDeleteSiteDto(siteDto);
        // Will throw an error if the element doesn't exist
        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == site.Id);
        if (!siteCheck) throw new KeyNotFoundException();

        return await _siteRepository.UpdateAsync(site);
    }

    public async Task<int> DeleteSiteAsync(UpdateDeleteSiteDto siteDto)
    {
        var site = UpdateDeleteSiteMapper.FromUpdateDeleteSiteDto(siteDto);
        // Will throw an error if the element doesn't exist
        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == site.Id);
        if (!siteCheck) throw new KeyNotFoundException();

        return await _siteRepository.DeleteAsync(site);
    }
}