using BlocCs.API.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<SiteModel> Sites { get; set; }
    // public DbSet<ServiceModel> Services { get; set; }
    // public DbSet<SalarieModel> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Database=annuaire_cubes;User ID=root;Password=;Pooling=true;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}