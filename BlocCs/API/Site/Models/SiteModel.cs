using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Site.Models;

public class SiteModel
{
    public int Id { get; set; }
    [Required] [StringLength(50)] public required string Nom { get; set; }
    [Required] [StringLength(100)] public required string Ville { get; set; }
}