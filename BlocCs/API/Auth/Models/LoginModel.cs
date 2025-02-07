using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Auth.Models;

public class LoginModel
{
    [Required] [StringLength(15)] public required string TelPortable { get; set; }
    [Required] public required string Password { get; set; }
    
}