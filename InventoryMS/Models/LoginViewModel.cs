using System;
using System.ComponentModel.DataAnnotations;
namespace InventoryMS.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Required Fild")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Required Fild")]
    public string Password { get; set; }

}
