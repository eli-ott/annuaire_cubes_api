using BlocCs.API.Auth.Models;

namespace BlocCs.API.Auth.Services;

/// <summary>
/// Auth service interface
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Login a user
    /// </summary>
    /// <param name="loginModel">The login information</param>
    /// <returns>A <see cref="string"/> that contains the JWT token</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    /// <exception cref="AuthenticationException"></exception>
    Task<string> Login(LoginModel loginModel);
}