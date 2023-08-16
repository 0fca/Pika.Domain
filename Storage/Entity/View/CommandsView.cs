namespace Pika.Domain.Storage.Entity.View;

public class CommandsView
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public HashSet<string> Headers { get; set; }
    public string Body { get; set; }
    
    public override string ToString()
    {
        return $@"{Name}{HeadersToString()} {Body}";
    }
    
    private string HeadersToString()
    {
        return Headers.Aggregate("", (current, header) => string.Concat(current, " ", header));
    }
}