namespace Pika.Domain.Storage.Entity.Event;

public class CategoryRemoved
{
    public Guid Guid { get; set; }
    public bool Remove { get; set; } = true;
}