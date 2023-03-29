namespace Pika.Domain.Storage.Entity.Event;

public class BucketModified
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> RoleClaims { get; set; } 
}