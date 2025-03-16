using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;
using BlocCs.Data;
using BlocCs.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.API.Site.Repositories;

/// <summary>
/// Repository for the sites
/// </summary>
public class SiteRepository : BaseRepository<SiteModel>, ISiteRepository
{
    /// <summary>
    /// Site repository constructur
    /// </summary>
    /// <param name="dbContext">The application database context</param>
    public SiteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}