using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Service.Mappers;

/// <summary>
/// Provides mappers for the service
/// </summary>
public class CreateServiceMapper
{
    /// <summary>
    /// Convert a <see cref="CreateServiceDto"/> to a <see cref="ServiceModel"/>
    /// </summary>
    /// <param name="service">An instance of <see cref="CreateServiceDto"/></param>
    /// <returns>An instance of <see cref="ServiceModel"/></returns>
    public static ServiceModel FromCreateServiceDto(CreateServiceDto service)
    {
        return new ServiceModel
        {
            Nom = service.Nom
        };
    }
}