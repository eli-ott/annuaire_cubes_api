using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Salarie.Mappers;

public class GetSalarieMapper
{
    public static GetSalarieDto ToGetSalarieDto(SalarieModel salarie, ServiceModel serviceModel, SiteModel siteModel)
    {
        return new GetSalarieDto
        {
            Id = salarie.Id,
            Email = salarie.Email,
            Nom = salarie.Nom,
            Prenom = salarie.Prenom,
            TelFixe = salarie.TelFixe,
            TelPortable = salarie.TelPortable,
            Service = serviceModel,
            Site = siteModel
        };
    }

    public static SalarieModel ToSalarieModel(GetSalarieDto salarieDto)
    {
        return new SalarieModel
        {
            Id = salarieDto.Id,
            Email = salarieDto.Email,
            Nom = salarieDto.Nom,
            Prenom = salarieDto.Prenom,
            TelFixe = salarieDto.TelFixe,
            TelPortable = salarieDto.TelPortable,
            Service = salarieDto.Service.Id,
            Site = salarieDto.Site.Id
        };
    }
}