using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Mappers;

public class UpdateDeleteSiteMapper
{
    public static SiteModel FromUpdateDeleteSiteDto(UpdateDeleteSiteDto updateDeleteSiteDto)
    {
        return new SiteModel
        {
            Id = updateDeleteSiteDto.Id,
            Nom = updateDeleteSiteDto.Nom,
            Ville = updateDeleteSiteDto.Ville,
        };
    }

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