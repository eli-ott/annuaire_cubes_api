using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.API.Salarie.Repositories;

/// <summary>
/// The repository for the salaries
/// </summary>
public class SalarieRepository : BaseRepository<SalarieModel>, ISalarieRepository
{
    /// <summary>
    /// The salarie repository constructor
    /// </summary>
    /// <param name="dbContext">The application database context</param>
    public SalarieRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// List all the salaries
    /// </summary>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    public async Task<List<GetSalarieDto>> ListAsync()
    {
        return await (from salarie in DbContext.Salaries
            join service in DbContext.Services on salarie.Service equals service.Id
            join site in DbContext.Sites on salarie.Site equals site.Id
            select new GetSalarieDto
            {
                Id = salarie.Id,
                Email = salarie.Email,
                Nom = salarie.Nom,
                Prenom = salarie.Prenom,
                TelFixe = salarie.TelFixe,
                TelPortable = salarie.TelPortable,
                Service = new ServiceModel
                {
                    Id = service.Id,
                    Nom = service.Nom,
                },
                Site = new SiteModel
                {
                    Id = site.Id,
                    Nom = site.Nom,
                    Ville = site.Ville
                }
            }).ToListAsync();
    }

    /// <summary>
    /// Find a salarie
    /// </summary>
    /// <param name="id">The id of the salarie</param>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    public async Task<GetSalarieDto> FindAsync(int id)
    {
        return await (from salarie in DbContext.Salaries
            join service in DbContext.Services on salarie.Service equals service.Id
            join site in DbContext.Sites on salarie.Site equals site.Id
            where salarie.Id == id
            select new GetSalarieDto
            {
                Id = salarie.Id,
                Email = salarie.Email,
                Nom = salarie.Nom,
                Prenom = salarie.Prenom,
                TelFixe = salarie.TelFixe,
                TelPortable = salarie.TelPortable,
                Service = new ServiceModel
                {
                    Id = service.Id,
                    Nom = service.Nom,
                },
                Site = new SiteModel
                {
                    Id = site.Id,
                    Nom = site.Nom,
                    Ville = site.Ville
                }
            }).FirstAsync();
    }
}