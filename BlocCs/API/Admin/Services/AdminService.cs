using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Mappers;
using BlocCs.API.Admin.Models;
using BlocCs.API.Admin.Repositories;

namespace BlocCs.API.Admin.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepo)
    {
        _adminRepository = adminRepo;
    }

    public async Task<List<AdminModel>> GetAllAdminsAsync()
    {
        return await _adminRepository.ListAsync();
    }

    public async Task<AdminModel?> GetAdminByIdAsync(int id)
    {
        return await _adminRepository.FindAsync(id);
    }

    public async Task<AdminModel> CreateAdminAsync(CreateAdminDto adminDto)
    {
        var admin = CreateAdminMapper.FromCreateUpdateAdminSto(adminDto);

        return await _adminRepository.AddAsync(admin);
    }

    public async Task<AdminModel> DeleteAdminAsync(AdminModel admin)
    {
        var adminCheck = await _adminRepository.AnyAsync(x => x.Id == admin.Id);
        if (!adminCheck) throw new KeyNotFoundException();
        
        await _adminRepository.DeleteAsync(admin);
        return admin;
    }
}