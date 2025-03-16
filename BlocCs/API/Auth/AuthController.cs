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
    /// <summary>
    /// Authentication service
    /// </summary>
    private readonly IAuthService _authService;

    /// <summary>
    /// Auth controller
    /// </summary>
    /// <param name="authService">Authentication service</param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Post endpoint
    /// </summary>
    /// <param name="loginModel">The login information</param>
    /// <returns>An instance of <see cref="string"/> that contains the token</returns>
    [HttpPost("login")]
    public async Task<ActionResult<string>> Post(LoginModel loginModel)
    {
        return Ok(Utils.RespondWithData(await _authService.Login(loginModel)));
    }
}