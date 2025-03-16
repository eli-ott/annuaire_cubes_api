using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Mappers;

/// <summary>
/// Provides a mapper methods for admin-related data transformations.
/// </summary>
public static class CreateAdminMapper
{
    /// <summary>
    /// Converts a <see cref="CreateAdminDto"/> to an <see cref="AdminModel"/>.
    /// </summary>
    /// <param name="admin">The DTO containing admin data.</param>
    /// <returns>An instance of <see cref="AdminModel"/> with mapped properties.</returns>
    public static AdminModel FromCreateUpdateAdminSto(CreateAdminDto adminDto)
    {
        return new AdminModel
        {
            IdUser = adminDto.IdUser,
        };
    }
}