namespace Pika.Domain.Storage.Entity.Event;

public sealed class CategoryCreated
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public HashSet<string> Mimes { get; set; }
    public Dictionary<string, List<string>> Tags { get; set; } = new();
    public CategoryCreated(string name, string description, IEnumerable<string> mimes)
    {
        this.Guid = Guid.NewGuid();
        this.Name = name;
        this.Mimes = new HashSet<string>(mimes);
        this.Description = description;
    }
}