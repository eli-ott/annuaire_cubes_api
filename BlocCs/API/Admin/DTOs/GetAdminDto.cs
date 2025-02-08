using System.ComponentModel.DataAnnotations;
using BlocCs.API.Service.Models;
using BlocCs.API.Site.Models;

namespace BlocCs.API.Admin.DTOs;

public class GetAdminDto
{
    public int IdUser { get; set; }
    public int IdAdmin { get; set; }
    [Required] [StringLength(100)] public required string Nom { get; set; }
    [Required] [StringLength(100)] public required string Prenom { get; set; }
    [Required] [StringLength(15)] public required string TelFixe { get; set; }
    [StringLength(15)] public string? TelPortable { get; set; }
    [Required] [StringLength(150)] public required string Email { get; set; }
    [Required] public required ServiceModel Service { get; set; }
    [Required] public required SiteModel Site { get; set; }
}