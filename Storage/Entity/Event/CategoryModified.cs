namespace Pika.Domain.Storage.Entity.Event;

public class CategoryModified
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public HashSet<string> Mimes { get; set; }

    public Dictionary<string, List<string>> Tags { get; set; }

    public CategoryModified(Guid id, string name, 
        string description, 
        HashSet<string> mimes,
        Dictionary<string, List<string>> tags)
    {
        this.Id = id;
        this.Name = name;
        this.Mimes = mimes;
        this.Tags = tags;
        this.Description = description;
    }
}