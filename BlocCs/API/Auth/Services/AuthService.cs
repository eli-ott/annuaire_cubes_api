using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using BlocCs.API.Admin.Repositories;
using BlocCs.API.Auth.Models;
using BlocCs.API.Salarie.Repositories;
using BlocCs.Shared;
using Microsoft.IdentityModel.Tokens;

namespace BlocCs.API.Auth.Services;

public class AuthService : IAuthService
{
    private readonly ISalarieRepository _salarieRepository;
    private readonly IAdminRepository _adminRepository;

    public AuthService(ISalarieRepository salarieRepository, IAdminRepository adminRepository)
    {
        _salarieRepository = salarieRepository;
        _adminRepository = adminRepository;
    }

    public async Task<string> Login(LoginModel loginModel)
    {
        var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD")
                            ?? throw new KeyNotFoundException("Admin password is missing in the environment.");

        // If password is wrong
        if (loginModel.Password != adminPassword) throw new AuthenticationException("Invalid password.");

        // Checks if the user exists
        var user = await _salarieRepository.FirstOrDefaultAsync(x => x.TelPortable == loginModel.TelPortable);
        if (user == null)
            throw new AuthenticationException("The user associated with this phone number does not exist.");

        // Check if the user is an admin
        var admin = await _adminRepository.FindAsync(user.Id);
        if (admin == null) throw new AuthenticationException("The user is not an administrator.");

        // Faire une liste de Claims 
        var claims = new List<Claim>
        {
            new Claim("UserId", admin.Id.ToString())
        };

        // Signer le token de connexion JWT
        var key = Environment.GetEnvironmentVariable("JWT_SECRET")
                  ?? throw new KeyNotFoundException("JWT_SECRET is missing in the environment.");
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key!)),
            SecurityAlgorithms.HmacSha256);

        // On créer un objet de token à partir de la clé de sécurité et l'on y ajoute une expiration, une audience et un issuer de sorte à pouvoir cibler nos clients d'API et éviter les tokens qui trainent trop longtemps dans la nature
        JwtSecurityToken jwt = new JwtSecurityToken(
            claims: claims,
            issuer: "Issuer",
            audience: "Audience",
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(12));

        // Générer le JWT à partir de l'objet JWT 
        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }
}