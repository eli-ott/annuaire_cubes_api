using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Mappers;

public class CreateAdminMapper
{
    public static AdminModel FromCreateUpdateAdminSto(CreateAdminDto adminDto)
    {
        return new AdminModel
        {
            IdUser = adminDto.IdUser,
        };
    }
}