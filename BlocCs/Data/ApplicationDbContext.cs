using BlocCs.API.Admin.Models;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Data;

/// <summary>
/// The application database context
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// The application database context constructor
    /// </summary>
    /// <param name="options">An instance of <see cref="DbContextOptions"/></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// The sites
    /// </summary>
    public DbSet<SiteModel> Sites { get; set; }
    /// <summary>
    /// The services
    /// </summary>
    public DbSet<ServiceModel> Services { get; set; }
    /// <summary>
    /// The salaries
    /// </summary>
    public DbSet<SalarieModel> Salaries { get; set; }
    /// <summary>
    /// The admins
    /// </summary>
    public DbSet<AdminModel> Admins { get; set; }

    /// <summary>
    /// On configuring
    /// </summary>
    /// <param name="optionsBuilder">An instance of <see cref="DbContextOptionsBuilder"/></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    /// <summary>
    /// On model creating
    /// </summary>
    /// <param name="modelBuilder">An instance of <see cref="ModelBuilder"/></param>
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