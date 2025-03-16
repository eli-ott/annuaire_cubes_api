using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Mappers;
using BlocCs.API.Admin.Models;
using BlocCs.API.Admin.Repositories;

namespace BlocCs.API.Admin.Services;

/// <summary>
/// The services for the admins
/// </summary>
public class AdminService : IAdminService
{
    /// <summary>
    /// The admin repository
    /// </summary>
    private readonly IAdminRepository _adminRepository;

    /// <summary>
    /// The admin service constructor
    /// </summary>
    /// <param name="adminRepo">The admin repository</param>
    public AdminService(IAdminRepository adminRepo)
    {
        _adminRepository = adminRepo;
    }

    /// <summary>
    /// Get a list of all the admins
    /// </summary>
    /// <returns>A task list of <see cref="GetAdminDto"/></returns>
    public async Task<List<GetAdminDto>> GetAllAdminsAsync()
    {
        return await _adminRepository.ListAsync();
    }

    /// <summary>
    /// Get an admin by id
    /// </summary>
    /// <param name="id">The admin's id</param>
    /// <returns>A task of <see cref="GetAdminDto"/></returns>
    public async Task<GetAdminDto?> GetAdminByIdAsync(int id)
    {
        return await _adminRepository.FindAsync(id);
    }

    /// <summary>
    /// Create a new admin
    /// </summary>
    /// <param name="adminDto">A instance of <see cref="CreateAdminDto"/> that contains the necessary information</param>
    /// <returns>A tak of <see cref="AdminModel"/></returns>
    public async Task<AdminModel> CreateAdminAsync(CreateAdminDto adminDto)
    {
        var admin = CreateAdminMapper.FromCreateUpdateAdminSto(adminDto);

        return await _adminRepository.AddAsync(admin);
    }

    /// <summary>
    /// Delete an admin
    /// </summary>
    /// <param name="adminModel">The admin to delete</param>
    /// <returns>A task of <see cref="AdminModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<AdminModel> DeleteAdminAsync(AdminModel adminModel)
    {
        var adminCheck = await _adminRepository.AnyAsync(x => x.Id == adminModel.Id);
        if (!adminCheck) throw new KeyNotFoundException();
        
        await _adminRepository.DeleteAsync(adminModel);
        return adminModel;
    }
}