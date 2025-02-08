using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Mappers;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Salarie.Repositories;
using BlocCs.API.Service.Repositories;
using BlocCs.API.Site.Repositories;

namespace BlocCs.API.Salarie.Services;

public class SalarieService : ISalarieService
{
    private readonly ISalarieRepository _salarieRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly ISiteRepository _siteRepository;

    public SalarieService(ISalarieRepository salarieRepository, IServiceRepository serviceRepository,
        ISiteRepository siteRepository)
    {
        _salarieRepository = salarieRepository;
        _serviceRepository = serviceRepository;
        _siteRepository = siteRepository;
    }

    public async Task<List<GetSalarieDto>> GetAllSalariesAsync()
    {
        return await _salarieRepository.ListAsync();
    }

    public async Task<GetSalarieDto?> GetSalarieByIdAsync(int id)
    {
        return await _salarieRepository.FindAsync(id);
    }

    public async Task<GetSalarieDto> CreateSalarieAsync(GetSalarieDto salarieDto)
    {
        var salarie = GetSalarieMapper.FromGetSalarieDto(salarieDto);

        var serviceCheck = await _serviceRepository.AnyAsync(x => x.Id == salarie.Service);
        if (!serviceCheck) throw new KeyNotFoundException("Service not found");

        var siteCheck = await _siteRepository.AnyAsync(x => x.Id == salarie.Site);
        if (!siteCheck) throw new KeyNotFoundException("Site not found");

        await _salarieRepository.AddAsync(salarie);
        
        var salarieDetails = await GetSalarieByIdAsync(salarie.Id);
            
        return salarieDetails!;
    }

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

    public async Task<SalarieModel> DeleteSalarieAsync(SalarieModel salarie)
    {
        var salarieCheck = await _salarieRepository.AnyAsync(x => x.Id == salarie.Id);
        if (!salarieCheck) throw new KeyNotFoundException();

        await _salarieRepository.DeleteAsync(salarie);
        return salarie;
    }
}