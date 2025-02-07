using BlocCs.API.Auth.Models;
using BlocCs.API.Auth.Services;
using BlocCs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Auth;

[ApiController]
[AllowAnonymous]
[Route("/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Post(LoginModel loginModel)
    {
        return Ok(Utils.RespondWithData(await _authService.Login(loginModel)));
    }
}