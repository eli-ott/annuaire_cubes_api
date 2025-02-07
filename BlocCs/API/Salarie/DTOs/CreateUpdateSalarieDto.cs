using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Salarie.DTOs;

public class CreateUpdateSalarieDto
{
    [Required] [StringLength(100)] public required string Nom { get; set; }
    [Required] [StringLength(100)] public required string Prenom { get; set; }
    [Required] [StringLength(15)] public required string TelFixe { get; set; }
    [StringLength(15)] public string? TelPortable { get; set; }
    [Required] [StringLength(150)] public required string Email { get; set; }
    [Required] public required int Service { get; set; }
    [Required] public required int Site { get; set; }
}