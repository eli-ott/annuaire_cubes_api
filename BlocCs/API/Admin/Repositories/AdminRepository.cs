using BlocCs.API.Admin.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Admin.Repositories;

public class AdminRepository : BaseRepository<AdminModel>, IAdminRepository
{
    public AdminRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}