using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Site.Mappers;

public class CreateSiteMapper
{
    public static SiteModel FromCreateSiteDto(CreateSiteDto createSiteDto)
    {
        return new SiteModel
        {
            Nom = createSiteDto.Nom,
            Ville = createSiteDto.Ville,
        };
    }
}