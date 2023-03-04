using Domain.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ApplicationUser
{
    public ApplicationUser()
    {

    }

    public ApplicationUser(Guid id, string username, string name, string password, ApplicationRole role, string phone, string email, bool isActive)
    {
        Id = id;
        UserName = username;
        Name = name;
        Password = password;
        Role = role;
        Phone = phone;
        Email = email;
        IsActive = isActive;
        
    }

    
    
    public Guid Id { get; set; }


    [Required(ErrorMessage = "The user name is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for user name is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for user name is 5 characters.")]
    [DisplayName("Username")]
    public string UserName { get; set; } = string.Empty;


    [Required(ErrorMessage = "The name is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for name is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for name is 5 characters.")]
    [DisplayName("Full Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Password is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for Password is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for Password is 5 characters.")]
    [DisplayName("Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Role is required.")]
    [DisplayName("Role")]
    public ApplicationRole Role { get; set; }

    [Phone]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "The phone namber is required.")]
    [DisplayName("Phone namber")]
    public string Phone { get; set; } = string.Empty;


    [MaxLength(200, ErrorMessage = "Maximumn characters for name is 200 characters.")]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("User activation")]
    public bool IsActive { get; set; }
}
