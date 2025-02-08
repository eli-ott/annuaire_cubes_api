using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Mappers;
using BlocCs.API.Admin.Models;
using BlocCs.API.Admin.Services;
using BlocCs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Admin;

[ApiController]
[Authorize]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAdminDto>>> Get()
    {
        return Ok(Utils.RespondWithData(await _adminService.GetAllAdminsAsync()));
    }

    [HttpPost]
    public async Task<ActionResult<AdminModel>> Post(CreateAdminDto adminDto)
    {
        return Ok(Utils.RespondWithData(await _adminService.CreateAdminAsync(adminDto)));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AdminModel>> Delete(int id)
    {
        var admin = GetAdminMapper.FromGetAdminDto(await _adminService.GetAdminByIdAsync(id)
                                                   ?? throw new NullReferenceException("Admin not found."));

        await _adminService.DeleteAdminAsync(admin);
        return Ok(Utils.RespondWithoutData());
    }
}