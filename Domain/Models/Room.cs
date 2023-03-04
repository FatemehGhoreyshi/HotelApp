using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Room
{
    public Room()
    {

    }

    public Room(Guid id, string title, string description, decimal price, RoomStatus status, Guid roomTypeId, RoomType? roomType, ICollection<Booking>? bookings)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Status = status;
        RoomTypeId = roomTypeId;
        RoomType = roomType;
        Bookings = bookings;
    }

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public RoomStatus Status { get; set; }


    [ForeignKey("RoomType")]
    public Guid RoomTypeId { get; set; }
    public virtual RoomType? RoomType { get; set; }

    public virtual ICollection<Booking>? Bookings { get; set; }
}
