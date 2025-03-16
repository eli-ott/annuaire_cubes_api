using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Mappers;

/// <summary>
/// Provides mappers for the sites
/// </summary>
public class UpdateDeleteSiteMapper
{
    /// <summary>
    /// Converts a <see cref="UpdateDeleteSiteDto"/> to a <see cref="SiteModel"/>
    /// </summary>
    /// <param name="updateDeleteSiteDto">An instance of <see cref="UpdateDeleteSiteDto"/></param>
    /// <returns>An instance of <see cref="SiteModel"/></returns>
    public static SiteModel FromUpdateDeleteSiteDto(UpdateDeleteSiteDto updateDeleteSiteDto)
    {
        return new SiteModel
        {
            Id = updateDeleteSiteDto.Id,
            Nom = updateDeleteSiteDto.Nom,
            Ville = updateDeleteSiteDto.Ville,
        };
    }

    /// <summary>
    /// Converts a <see cref="SiteModel"/> to a <see cref="UpdateDeleteSiteDto"/>
    /// </summary>
    /// <param name="site">An instance of <see cref="SiteModel"/></param>
    /// <returns>An instance of <see cref="UpdateDeleteSiteDto"/></returns>
    public static UpdateDeleteSiteDto ToUpdateDeleteSiteDto(SiteModel site)
    {
        return new UpdateDeleteSiteDto
        {
            Id = site.Id,
            Nom = site.Nom,
            Ville = site.Ville,
        };
    }
}