using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Salarie.Services;

/// <summary>
/// The interface of the salarie service
/// </summary>
public interface ISalarieService
{
    /// <summary>
    /// Get all the salaries
    /// </summary>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    Task<List<GetSalarieDto>> GetAllSalariesAsync();

    /// <summary>
    /// Get a salarie by its id
    /// </summary>
    /// <param name="id">The id of the salarie</param>
    /// <returns>An task of <see cref="GetSalarieDto"/></returns>
    Task<GetSalarieDto?> GetSalarieByIdAsync(int id);

    /// <summary>
    /// Create a new salarie
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A task of <see cref="GetSalarieDto"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<GetSalarieDto> CreateSalarieAsync(GetSalarieDto updateSalarieDto);

    /// <summary>
    /// Update the information of a salarie
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A task of <see cref="GetSalarieDto"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<GetSalarieDto> UpdateSalarieAsync(GetSalarieDto salarie);

    /// <summary>
    /// Delete a salarie
    /// </summary>
    /// <param name="salarie">An isntance of <see cref="SalarieModel"/></param>
    /// <returns>A task of <see cref="SalarieModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<SalarieModel> DeleteSalarieAsync(SalarieModel salarieModel);
}