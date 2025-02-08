using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;
using BlocCs.API.Salarie.DTOs;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Admin.Repositories;

public interface IAdminRepository : IRepository<AdminModel>
{
    Task<List<GetAdminDto>> ListAsync();
    Task<GetAdminDto> FindAsync(int id);
}