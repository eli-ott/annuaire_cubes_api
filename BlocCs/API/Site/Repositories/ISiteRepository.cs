using BlocCs.API.Site.DTOs;
using BlocCs.API.Site.Models;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Site.Repositories;

/// <summary>
/// The interface for the site repository
/// </summary>
public interface ISiteRepository : IRepository<SiteModel>
{
}