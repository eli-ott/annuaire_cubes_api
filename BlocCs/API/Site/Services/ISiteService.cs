using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Services;

public interface ISiteService
{
    Task<List<SiteModel>> GetAllSitesAsync();
    Task<SiteModel?> GetSiteByIdAsync(int id);
    Task<SiteModel> CreateSiteAsync(CreateSiteDto siteDto);
    Task<SiteModel> UpdateSiteAsync(UpdateDeleteSiteDto siteDto);
    Task<int> DeleteSiteAsync(UpdateDeleteSiteDto siteDto);
}