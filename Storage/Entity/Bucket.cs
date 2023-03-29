using Pika.Domain.Storage.Entity.Event;

namespace Pika.Domain.Storage.Entity;

public sealed class Bucket : AggregateBase
{
    public string Name { get; set; }
    public List<string> RoleClaims { get; set; }

    public Bucket(string name, List<string> roleClaims)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Category name cannot be empty", nameof(name));
        }
        var @event = new BucketCreated(name, roleClaims);
        Apply(@event);
        AddUncommittedEvent(@event);
    }
    
    private Bucket(){}
    
    private void Apply(BucketCreated @event)
    {
        Id = @event.Id; 
        Name = @event.Name;
        RoleClaims = @event.RoleClaims;
        Version++; 
    }
}