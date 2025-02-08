using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Mappers;

public class GetAdminMapper
{
    public static AdminModel FromGetAdminDto(GetAdminDto adminDto)
    {
        return new AdminModel
        {
            Id = adminDto.IdAdmin,
            IdUser = adminDto.IdUser
        };
    }
}