using BlocCs.API.Auth.Models;

namespace BlocCs.API.Auth.Services;

public interface IAuthService
{
    Task<string> Login(LoginModel loginModel);
}