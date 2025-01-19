using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Service.Mappers;

public class CreateServiceMapper
{
    public static ServiceModel FromCreateServiceDto(CreateServiceDto service)
    {
        return new ServiceModel
        {
            Nom = service.Nom
        };
    }
}