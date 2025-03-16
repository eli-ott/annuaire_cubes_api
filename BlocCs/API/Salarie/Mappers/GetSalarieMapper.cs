using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Salarie.Mappers;

/// <summary>
/// Provides a mapper for the salaries DTOs and Models
/// </summary>
public class GetSalarieMapper
{
    /// <summary>
    /// Combines a <see cref="SalarieModel"/>, <see cref="ServiceModel"/> and <see cref="SiteModel"/> to a <see cref="GetSalarieDto"/>
    /// </summary>
    /// <param name="salarie">An instance of <see cref="SalarieModel"/></param>
    /// <param name="serviceModel">An instance of <see cref="ServiceModel"/></param>
    /// <param name="siteModel">An instance of <see cref="SiteModel"/></param>
    /// <returns>An instance of <see cref="GetSalarieDto"/></returns>
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

    /// <summary>
    /// Converts a <see cref="GetSalarieDto"/> to a <see cref="SalarieModel"/>
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>An instance of <see cref="SalarieModel"/></returns>
    public static SalarieModel FromGetSalarieDto(GetSalarieDto salarieDto)
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