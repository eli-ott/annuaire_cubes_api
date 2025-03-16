using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Extensions;

/// <summary>
/// Provides extension methods for admin-related data transformations.
/// </summary>
public static class AdminExtension
{
    /// <summary>
    /// Converts a <see cref="GetAdminDto"/> to an <see cref="AdminModel"/>.
    /// </summary>
    /// <param name="admin">The DTO containing admin data.</param>
    /// <returns>An instance of <see cref="AdminModel"/> with mapped properties.</returns>
    public static AdminModel ToAdminModel(this GetAdminDto admin)
    {
        return new AdminModel
        {
            Id = admin.IdAdmin,
            IdUser = admin.IdUser
        };
    }
}