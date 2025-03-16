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
    /// <summary>
    /// Admin service
    /// </summary>
    private readonly IAdminService _adminService;

    /// <summary>
    /// Admin controller constructor
    /// </summary>
    /// <param name="adminService"></param>
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    /// <summary>
    /// Get all endpoint
    /// </summary>
    /// <returns>A tasked action result containing a list of <see cref="GetAdminDto"/></returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAdminDto>>> Get()
    {
        return Ok(Utils.RespondWithData(await _adminService.GetAllAdminsAsync()));
    }

    /// <summary>
    /// Post endpoint
    /// </summary>
    /// <param name="adminDto">The admin to create</param>
    /// <returns>A tasked action result containing a <see cref="AdminModel"/></returns>
    [HttpPost]
    public async Task<ActionResult<AdminModel>> Post(CreateAdminDto adminDto)
    {
        return Ok(Utils.RespondWithData(await _adminService.CreateAdminAsync(adminDto)));
    }

    /// <summary>
    /// Delete endpoint
    /// </summary>
    /// <param name="id">The id of the admin to delete</param>
    /// <returns>A tasked action result containing a <see cref="AdminModel"/></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<AdminModel>> Delete(int id)
    {
        var admin = GetAdminMapper.FromGetAdminDto(await _adminService.GetAdminByIdAsync(id)
                                                   ?? throw new NullReferenceException("Admin not found."));

        await _adminService.DeleteAdminAsync(admin);
        return Ok(Utils.RespondWithoutData());
    }
}