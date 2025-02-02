using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<SiteModel> Sites { get; set; }
    public DbSet<ServiceModel> Services { get; set; }
    // public DbSet<SalarieModel> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}