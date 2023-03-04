using Domain.Models.Enums;
using Domain.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Customer
{
    public Customer()
    {

    }

    public Customer(Guid id, string firstName, string lastName, string phone, string email, Address address, Gender gender, CustomerCategory category)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Address = address;
        Gender = gender;
        Category = category;

    }

    public Guid Id { get; set; }

    [Required(ErrorMessage = "The first name is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for first name is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for first name is 5 characters.")]
    [DisplayName("First name")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "The last name is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for last name is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for last name is 5 characters.")]
    [DisplayName("Last name")]
    public string LastName { get; set; } = string.Empty;

    [Phone]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "The phone namber is required.")]
    [DisplayName("Phone namber")]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "Maximumn characters for Address is 1000 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for Address is 5 characters.")]
    [DisplayName("Address")]
    public Address? Address { get; set; }

    [Required(ErrorMessage = "The Gender is required.")]
    [DisplayName("Gender")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "The Category is required.")]
    [DisplayName("Category")]
    public CustomerCategory Category { get; set; }


    [ForeignKey("Customer Detail Id")]
    public Guid CustomerDetailId { get; set; }
    public virtual CustomerDetail? CustomerDetail { get; set; }

    public virtual ICollection<Booking>? Bookings { get; set; }
    public virtual ICollection<Payment>? Payments { get; set; }
}
