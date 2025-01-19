using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Service.Models;

public class ServiceModel
{
    public int Id { get; set; }
    [Required] [StringLength(50)] public required string Nom { get; set; }
}