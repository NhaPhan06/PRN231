using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOS.Request;

public class LoginRequest
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}