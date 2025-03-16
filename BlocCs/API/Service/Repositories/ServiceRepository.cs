using BlocCs.API.Service.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Service.Repositories;

/// <summary>
/// The repository for the service
/// </summary>
public class ServiceRepository : BaseRepository<ServiceModel>, IServiceRepository
{
    /// <summary>
    /// The salarie repository constructor
    /// </summary>
    /// <param name="dbContext">The application database context</param>
    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}