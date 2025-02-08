using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.API.Service.DTOs;
using BlocCs.API.Service.Models;

namespace BlocCs.API.Salarie.Services;

public interface ISalarieService
{
    Task<List<GetSalarieDto>> GetAllSalariesAsync();
    Task<GetSalarieDto?> GetSalarieByIdAsync(int id);
    Task<GetSalarieDto> CreateSalarieAsync(GetSalarieDto updateSalarieDto);
    Task<GetSalarieDto> UpdateSalarieAsync(GetSalarieDto salarie);
    Task<SalarieModel> DeleteSalarieAsync(SalarieModel salarieModel);
}