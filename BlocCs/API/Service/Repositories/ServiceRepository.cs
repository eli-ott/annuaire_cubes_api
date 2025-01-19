using BlocCs.API.Service.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Service.Repositories;

public class ServiceRepository : BaseRepository<ServiceModel>, IServiceRepository
{
    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}