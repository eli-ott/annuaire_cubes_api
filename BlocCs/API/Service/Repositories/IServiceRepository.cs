using BlocCs.API.Service.Models;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Service.Repositories;

/// <summary>
/// The interface for the service repository
/// </summary>
public interface IServiceRepository: IRepository<ServiceModel>
{
}