using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.API.Admin.Repositories;

public class AdminRepository : BaseRepository<AdminModel>, IAdminRepository
{
    public AdminRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<GetAdminDto>> ListAsync()
    {
        return await (from admin in DbContext.Admins
            join salarie in DbContext.Salaries on admin.IdUser equals salarie.Id
            join service in DbContext.Services on salarie.Service equals service.Id
            join site in DbContext.Sites on salarie.Site equals site.Id
            select new GetAdminDto
            {
                IdAdmin = admin.Id,
                IdUser = salarie.Id,
                Nom = salarie.Nom,
                Prenom = salarie.Prenom,
                Email = salarie.Email,
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
    
    public async Task<GetAdminDto> FindAsync(int id)
    {
        return await (from admin in DbContext.Admins
            join salarie in DbContext.Salaries on admin.IdUser equals salarie.Id
            join service in DbContext.Services on salarie.Service equals service.Id
            join site in DbContext.Sites on salarie.Site equals site.Id
            where admin.Id == id
            select new GetAdminDto
            {
                IdAdmin = admin.Id,
                IdUser = salarie.Id,
                Nom = salarie.Nom,
                Prenom = salarie.Prenom,
                Email = salarie.Email,
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