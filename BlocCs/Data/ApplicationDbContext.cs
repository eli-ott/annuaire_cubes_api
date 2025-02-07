using BlocCs.API.Admin.Models;
using BlocCs.API.Salarie.Models;
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
    public DbSet<SalarieModel> Salaries { get; set; }
    public DbSet<AdminModel> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiteModel>().HasData(
            new SiteModel
            {
                Id = 1,
                Nom = "Siège administratif",
                Ville = "Paris"
            },
            new SiteModel
            {
                Id = 2,
                Nom = "Site de production",
                Ville = "Nantes"
            },
            new SiteModel
            {
                Id = 3,
                Nom = "Site de production",
                Ville = "Toulouse"
            },
            new SiteModel
            {
                Id = 4,
                Nom = "Site de production",
                Ville = "Nice"
            },
            new SiteModel
            {
                Id = 5,
                Nom = "Site de production",
                Ville = "Lille"
            }
        );
    }
}