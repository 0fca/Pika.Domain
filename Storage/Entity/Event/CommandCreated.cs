namespace Pika.Domain.Storage.Entity.Event;

public class CommandCreated
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public HashSet<string> Headers { get; set; }
    
    public string Body { get; set; }
    
    public CommandCreated(string name, HashSet<string> headers, string body)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Headers = headers;
        this.Body = body;
    }
}