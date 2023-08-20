using Pika.Domain.Storage.Entity.Event;

namespace Pika.Domain.Storage.Entity;

public class Command : AggregateBase
{
    public string Name { get; set; }
    public HashSet<string> Headers { get; set; }
    public string Body { get; set; }

    public Command(string name, HashSet<string> headers, string body)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Command name cannot be empty", nameof(name));
        }
        var @event = new CommandCreated(name, headers, body);
        Apply(@event);
        AddUncommittedEvent(@event);
    }

    public override string ToString()
    {
        return $@"{Name}{HeadersToString()} {Body}";
    }
    
    private Command() { }

    private void Apply(CommandCreated @event)
    {
        Id = @event.Id;
        Body = @event.Body;
        Headers = @event.Headers;
        Name = @event.Name;
        Version++;
    }

    private string HeadersToString()
    {
        return Headers.Aggregate("", (current, header) => string.Concat(current, " ", header));
    }
}