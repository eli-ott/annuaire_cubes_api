using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Admin.DTOs;

public class CreateAdminDto
{
    [Required] public required int IdUser { get; set; }
}