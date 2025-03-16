using System.Text;
using BlocCs.API.Admin.Repositories;
using BlocCs.API.Admin.Services;
using BlocCs.API.Auth.Services;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Salarie.Services;
using BlocCs.API.Service.Services;
using BlocCs.API.Service.Repositories;
using BlocCs.API.Site.Repositories;
using BlocCs.API.Site.Services;
using BlocCs.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BlocCs.Extensions;

/// <summary>
/// Inject all the dependencies
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Inject dependencies constructor
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    public static void InjectDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.AddSwagger();
        builder.AddRepositories();
        builder.AddServices();
        builder.AddEfCoreConfiguration();
        builder.AddJwt();
    }

    /// <summary>
    /// Adds the swagger to the project
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    /// <summary>
    /// Add the repositories
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteRepository, SiteRepository>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<ISalarieRepository, SalarieRepository>();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
    }

    /// <summary>
    /// Add the services
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    private static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteService, SiteService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();
        builder.Services.AddScoped<ISalarieService, SalarieService>();
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
    }

    /// <summary>
    /// Adds the ef core configuration
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    private static void AddEfCoreConfiguration(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    /// <summary>
    /// Adds JWT token
    /// </summary>
    /// <param name="builder">An instance of <see cref="WebApplicationBuilder"/></param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void AddJwt(this WebApplicationBuilder builder)
    {
        var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ??
                        throw new InvalidOperationException("JWT secret 'JWT_SECRET' not found.");

        var key = Encoding.ASCII.GetBytes(jwtSecret);

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Mettre à true en production
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // Configurer selon les besoins
                    ValidateAudience = false, // Configurer selon les besoins
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        builder.Services.AddAuthorization();
    }
}