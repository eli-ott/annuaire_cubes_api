using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;

namespace BlocCs.API.Salarie.Mappers;

public class CreateUpdateSalarieMapper
{
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