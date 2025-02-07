using System.ComponentModel.DataAnnotations;

namespace BlocCs.API.Admin.Models;

public class AdminModel
{
    public int Id { get; set; }
    [Required] public required int IdUser { get; set; }
}