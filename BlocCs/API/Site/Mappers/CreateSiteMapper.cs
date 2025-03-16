using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Mappers;

/// <summary>
/// Provides mappers for the sites
/// </summary>
public class CreateSiteMapper
{
    /// <summary>
    /// Convert a <see cref="CreateSiteDto"/> to a <see cref="SiteModel"/>
    /// </summary>
    /// <param name="createSiteDto">An instance of <see cref="CreateSiteDto"/></param>
    /// <returns>An instance of <see cref="SiteModel"/></returns>
    public static SiteModel FromCreateSiteDto(CreateSiteDto createSiteDto)
    {
        return new SiteModel
        {
            Nom = createSiteDto.Nom,
            Ville = createSiteDto.Ville,
        };
    }
}