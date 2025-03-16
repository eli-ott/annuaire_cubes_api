using BlocCs.API.Admin.Models;
using BlocCs.API.Admin.DTOs;

namespace BlocCs.API.Admin.Services;

/// <summary>
/// The interface for the admin service
/// </summary>
public interface IAdminService
{
    /// <summary>
    /// Get a list of all the admins
    /// </summary>
    /// <returns>A task list of <see cref="GetAdminDto"/></returns>
    Task<List<GetAdminDto>> GetAllAdminsAsync();
    /// <summary>
    /// Get an admin by id
    /// </summary>
    /// <param name="id">The admin's id</param>
    /// <returns>A task of <see cref="GetAdminDto"/></returns>
    Task<GetAdminDto?> GetAdminByIdAsync(int id);
    /// <summary>
    /// Create a new admin
    /// </summary>
    /// <param name="adminDto">A instance of <see cref="CreateAdminDto"/> that contains the necessary information</param>
    /// <returns>A tak of <see cref="AdminModel"/></returns>
    Task<AdminModel> CreateAdminAsync(CreateAdminDto adminDto);
    /// <summary>
    /// Delete an admin
    /// </summary>
    /// <param name="adminModel">The admin to delete</param>
    /// <returns>A task of <see cref="AdminModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<AdminModel> DeleteAdminAsync(AdminModel adminModel);
}