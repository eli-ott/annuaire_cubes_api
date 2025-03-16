using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Salarie.Repositories;

/// <summary>
/// The salarie repository interface
/// </summary>
public interface ISalarieRepository: IRepository<SalarieModel>
{
    /// <summary>
    /// List all the salaries
    /// </summary>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    public Task<List<GetSalarieDto>> ListAsync();
    /// <summary>
    /// Find a salarie
    /// </summary>
    /// <param name="id">The id of the salarie</param>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    public Task<GetSalarieDto> FindAsync(int id);
}