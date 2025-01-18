using BlocCs.API.Site.Repositories;
using BlocCs.API.Site.Services;
using BlocCs.Data;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Extensions;

public static class DependencyInjectionExtensions
{
    public static void InjectDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.AddSwagger();
        builder.AddRepositories();
        builder.AddServices();
        builder.AddEfCoreConfiguration();
    }
    
    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
    
    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteRepository, SiteRepository>();
    }

    private static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteService, SiteService>();
    }

    private static void AddEfCoreConfiguration(this WebApplicationBuilder builder) 
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}