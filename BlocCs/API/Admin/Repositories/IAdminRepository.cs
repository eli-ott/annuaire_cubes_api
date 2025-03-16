using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;
using BlocCs.API.Salarie.DTOs;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Admin.Repositories;

/// <summary>
/// The interface for the admin repository
/// </summary>
public interface IAdminRepository : IRepository<AdminModel>
{
    /// <summary>
    /// List all the admins
    /// </summary>
    /// <returns>A task list of <see cref="GetAdminDto"/></returns>
    Task<List<GetAdminDto>> ListAsync();
    /// <summary>
    /// Get an admin based on its id
    /// </summary>
    /// <param name="id">The id of the admin</param>
    /// <returns>A task of <see cref="GetAdminDto"/>></returns>
    Task<GetAdminDto?> FindAsync(int id);
}