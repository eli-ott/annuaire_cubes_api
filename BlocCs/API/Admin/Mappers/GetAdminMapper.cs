using BlocCs.API.Admin.DTOs;
using BlocCs.API.Admin.Models;

namespace BlocCs.API.Admin.Mappers;

/// <summary>
/// Provides a mapper methods for admin-related data transformations.
/// </summary>
public static class GetAdminMapper
{
    /// <summary>
    /// Converts a <see cref="GetAdminDto"/> to an <see cref="AdminModel"/>.
    /// </summary>
    /// <param name="admin">The DTO containing admin data.</param>
    /// <returns>An instance of <see cref="AdminModel"/> with mapped properties.</returns>
    public static AdminModel FromGetAdminDto(GetAdminDto adminDto)
    {
        return new AdminModel
        {
            Id = adminDto.IdAdmin,
            IdUser = adminDto.IdUser
        };
    }
}