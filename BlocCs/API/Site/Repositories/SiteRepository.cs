using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Site.Repositories;

public class SiteRepository : BaseRepository<SiteModel>, ISiteRepository
{
    public SiteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}