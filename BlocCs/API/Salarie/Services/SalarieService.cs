using BlocCs.API.Admin.Extensions;
using BlocCs.API.Admin.Repositories;
using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Mappers;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Service.Repositories;
using BlocCs.API.Site.Repositories;

namespace BlocCs.API.Salarie.Services;

/// <summary>
/// The salarie services
/// </summary>
public class SalarieService : ISalarieService
{
    /// <summary>
    /// The salarie repository
    /// </summary>
    private readonly ISalarieRepository _salarieRepository;
    /// <summary>
    /// The service repository
    /// </summary>
    private readonly IServiceRepository _serviceRepository;
    /// <summary>
    /// The site repository
    /// </summary>
    private readonly ISiteRepository _siteRepository;
    /// <summary>
    /// The admin repository
    /// </summary>
    private readonly IAdminRepository _adminRepository;

    /// <summary>
    /// The salarie service constructor
    /// </summary>
    /// <param name="salarieRepository">The salarie repository</param>
    /// <param name="serviceRepository">The service repository</param>
    /// <param name="siteRepository">The site repository</param>
    /// <param name="adminRepository">The admin repository</param>
    public SalarieService(ISalarieRepository salarieRepository, IServiceRepository serviceRepository,
        ISiteRepository siteRepository, IAdminRepository adminRepository)
    {
        _salarieRepository = salarieRepository;
        _serviceRepository = serviceRepository;
        _siteRepository = siteRepository;
        _adminRepository = adminRepository;
    }

    /// <summary>
    /// Get all the salaries
    /// </summary>
    /// <returns>A tasked list of <see cref="GetSalarieDto"/></returns>
    public async Task<List<GetSalarieDto>> GetAllSalariesAsync()
    {
        return await _salarieRepository.ListAsync();
    }

    /// <summary>
    /// Get a salarie by its id
    /// </summary>
    /// <param name="id">The id of the salarie</param>
    /// <returns>An task of <see cref="GetSalarieDto"/></returns>
    public async Task<GetSalarieDto?> GetSalarieByIdAsync(int id)
    {
        return await _salarieRepository.FindAsync(id);
    }

    /// <summary>
    /// Create a new salarie
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A task of <see cref="GetSalarieDto"/></returns>
    /// <exception cref="BadHttpRequestException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<GetSalarieDto> CreateSalarieAsync(GetSalarieDto salarieDto)
    {
        var salarie = GetSalarieMapper.FromGetSalarieDto(salarieDto);
        
        var foundSalarieWithPhone = _salarieRepository.FirstOrDefaultAsync(x => x.TelPortable == salarieDto.TelPortable);
        if (foundSalarieWithPhone != null)
        {
            throw new BadHttpRequestException("Un utilisateur avec ce numéro de téléphone portable existe déjà");
        }

        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == salarie.Service);
        if (!serviceCheck) throw new KeyNotFoundException("Service not found");

        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == salarie.Site);
        if (!siteCheck) throw new KeyNotFoundException("Site not found");

        await _salarieRepository.AddAsync(salarie);

        var salarieDetails = await GetSalarieByIdAsync(salarie.Id);

        return salarieDetails!;
    }

    /// <summary>
    /// Update the information of a salarie
    /// </summary>
    /// <param name="salarieDto">An instance of <see cref="GetSalarieDto"/></param>
    /// <returns>A task of <see cref="GetSalarieDto"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<GetSalarieDto> UpdateSalarieAsync(GetSalarieDto salarieDto)
    {
        var salarie = GetSalarieMapper.FromGetSalarieDto(salarieDto);

        var salarieCheck = await _salarieRepository.AnyAsync(x => x.Id == salarie.Id);
        if (!salarieCheck) throw new KeyNotFoundException();

        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == salarie.Service);
        if (!serviceCheck) throw new KeyNotFoundException("Service not found");

        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == salarie.Site);
        if (!siteCheck) throw new KeyNotFoundException("Site not found");

        await _salarieRepository.UpdateAsync(salarie);

        var salarieDetails = await GetSalarieByIdAsync(salarie.Id);

        return salarieDetails!;
    }

    /// <summary>
    /// Delete a salarie
    /// </summary>
    /// <param name="salarie">An isntance of <see cref="SalarieModel"/></param>
    /// <returns>A task of <see cref="SalarieModel"/></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<SalarieModel> DeleteSalarieAsync(SalarieModel salarie)
    {
        var salarieCheck = await _salarieRepository.AnyAsync(x => x.Id == salarie.Id);
        if (!salarieCheck) throw new KeyNotFoundException();

        var foundAdmin = await _adminRepository.FindAsync(salarie.Id);
        if (foundAdmin != null)
        {
            await _adminRepository.DeleteAsync(foundAdmin.ToAdminModel());
        }

        await _salarieRepository.DeleteAsync(salarie);
        return salarie;
    }
}