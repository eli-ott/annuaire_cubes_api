using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Extensions;

public static class AdminExtension
{
    public static AdminModel ToAdminModel(this GetAdminDto admin)
    {
        return new AdminModel
        {
            Id = admin.IdAdmin,
            IdUser = admin.IdUser
        };
    }
}