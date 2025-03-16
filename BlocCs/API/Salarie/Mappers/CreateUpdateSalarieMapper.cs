using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;

namespace BlocCs.API.Salarie.Mappers;

/// <summary>
/// Provides mapper for the salarie DTOs and Models
/// </summary>
public class CreateUpdateSalarieMapper
{
    /// <summary>
    /// Convert a <see cref="CreateUpdateSalarieDto"/> to a <see cref="SalarieModel"/>
    /// </summary>
    /// <param name="updateSalarieDto">The <see cref="CreateUpdateSalarieDto"/> to map</param>
    /// <returns>An instance of <see cref="SalarieModel"/></returns>
    public static SalarieModel FromCreateUpdateSalarieDto(CreateUpdateSalarieDto updateSalarieDto)
    {
        return new SalarieModel
        {
            Nom = updateSalarieDto.Nom,
            Prenom = updateSalarieDto.Prenom,
            TelFixe = updateSalarieDto.TelFixe,
            TelPortable = updateSalarieDto.TelPortable,
            Email = updateSalarieDto.Email,
            Service = updateSalarieDto.Service,
            Site = updateSalarieDto.Site
        };
    }
}