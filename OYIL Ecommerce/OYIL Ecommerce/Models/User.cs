using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OYIL_Ecommerce.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage ="This field is required")]
    [EmailAddress(ErrorMessage ="Invalid Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Password must be at least 8 characters, contain 1 uppercase, 1 lowercase, and 1 number, with no special characters.")]
    public string Password { get; set; } = null!;

    [NotMapped] // this property will not be mapped to the database
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    public string? Role { get; set; }
}
