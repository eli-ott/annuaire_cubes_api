using BlocCs.API.Admin.Models;
using BlocCs.API.Admin.DTOs;

namespace BlocCs.API.Admin.Services;

public interface IAdminService
{
    Task<List<GetAdminDto>> GetAllAdminsAsync();
    Task<GetAdminDto?> GetAdminByIdAsync(int id);
    Task<AdminModel> CreateAdminAsync(CreateAdminDto adminDto);
    Task<AdminModel> DeleteAdminAsync(AdminModel adminModel);
}