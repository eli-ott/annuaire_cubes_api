using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Service.DTOs;

public class CreateServiceDto
{
    [Required] [StringLength(50)] public required string Nom { get; set; }
}