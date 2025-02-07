using BlocCs.API.Salarie.DTOs;
using BlocCs.API.Salarie.Models;
using BlocCs.Shared.Repositories;

namespace BlocCs.API.Salarie.Repositories;

public interface ISalarieRepository: IRepository<SalarieModel>
{
    public Task<List<GetSalarieDto>> ListAsync();
    public Task<GetSalarieDto> FindAsync(int id);
}