using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Services;

/// <summary>
/// The interface for the sites
/// </summary>
public interface ISiteService
{
    /// <summary>
    /// Get all the sites
    /// </summary>
    /// <returns>A tasked list of <see cref="SiteModel"/></returns>
    Task<List<SiteModel>> GetAllSitesAsync();
    /// <summary>
    /// Get a site by its id
    /// </summary>
    /// <param name="id">An instance of <see cref="int"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    Task<SiteModel?> GetSiteByIdAsync(int id);
    /// <summary>
    /// Create a new site
    /// </summary>
    /// <param name="createSiteDto">An instance of <see cref="CreateSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    Task<SiteModel> CreateSiteAsync(CreateSiteDto siteDto);
    /// <summary>
    /// Update a site
    /// </summary>
    /// <param name="siteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<SiteModel> UpdateSiteAsync(UpdateDeleteSiteDto siteDto);
    /// <summary>
    /// Delete a site
    /// </summary>
    /// <param name="siteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>A task of <see cref="SiteModel"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<SiteModel> DeleteSiteAsync(UpdateDeleteSiteDto siteDto);
}