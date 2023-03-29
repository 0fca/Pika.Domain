namespace Pika.Domain.Storage.Entity.View;

public class BucketsView
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public List<string> RoleClaims { get; set; }
}