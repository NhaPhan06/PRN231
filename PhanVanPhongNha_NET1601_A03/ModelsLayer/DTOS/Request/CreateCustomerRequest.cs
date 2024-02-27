using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Runtime.CompilerServices;

namespace ModelsLayer.DTOS.Request;

public class CreateCustomerRequest
{
    
    [Required, EmailAddress] 
    public string EmailAddress { get; set; } = null!;
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? CustomerFullName { get; set; }
    [Required, RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})", ErrorMessage="Invalid Value")]
    public string? Telephone { get; set; }
    [Required]
    [DateTimeRangeValidator("1900-01-01T00:00:00",  "2010-01-20T00:00:00", ErrorMessage = "Ngày phải nằm trong khoảng từ 01/01/1900 đến 01/01/2010.")]
    public DateTime? CustomerBirthday { get; set; }

}