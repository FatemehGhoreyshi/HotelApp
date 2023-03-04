using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Booking
{
    public Booking()
    {

    }

    public Booking(Guid id, string title, DateTime checkInDate, DateTime checkOutDate, Guid customerId, Customer? customer, Guid roomId, Room? room, BookingStatus status)
    {
        Id = id;
        Title = title;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        CustomerId = customerId;
        Customer = customer;
        RoomId = roomId;
        Room = room;
        Status = status;
    }

    public Guid Id { get; set; }

    [Required(ErrorMessage = "The title is required.")]
    [MaxLength(100, ErrorMessage = "Maximumn characters for title is 100 characters.")]
    [MinLength(5, ErrorMessage = "Minimum characters for title is 5 characters.")]
    [DisplayName("Title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Check in date is required.")]
    [DisplayName("Check in")]
    public DateTime CheckInDate { get; set; }

    [Required(ErrorMessage = "The Check out date is required.")]
    [DisplayName("Check out")]
    public DateTime CheckOutDate { get; set; }

    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }
    public virtual Customer? Customer  { get; set; }

    [ForeignKey("Room")]
    public Guid RoomId { get; set; }
    public virtual Room? Room { get; set; }

    [Required(ErrorMessage = "The Status is required.")]
    [DisplayName("Status")]
    public BookingStatus Status { get; set; }
}
