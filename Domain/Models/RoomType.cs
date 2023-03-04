namespace Domain.Models;

public class RoomType
{

    public RoomType()
    {

    }

    public RoomType(Guid id, string title, string description, bool isAvailable, ICollection<Room>? rooms)
    {
        Id = id;
        Title = title;
        Description = description;
        IsAvailable = isAvailable;
        Rooms = rooms;
    }

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsAvailable { get; set; }


    public virtual ICollection<Room>? Rooms { get; set; }
}
