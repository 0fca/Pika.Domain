namespace Pika.Domain.Storage.Entity.View;

public class CategoriesView
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    
    public HashSet<string> Mimes { get; set; }
    public Dictionary<string, List<string>> Tags { get; set; }
    public bool IsArchived { get; set; }
}