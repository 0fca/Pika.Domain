using System.Collections;
using System.Text;
using Pika.Domain.Infrastructure;
using Pika.Domain.Storage.Entity.Event;

namespace Pika.Domain.Storage.Entity;

public sealed class Category : AggregateBase
{
    public string Name { get; set; }
    public HashSet<string> Mimes { get; set; } = new();
    
    public string Description { get; set; }

    public Dictionary<string, List<string>>? Tags { get; set; } = new();
    
    public Category(string name, string description, List<string> mimes)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Category name cannot be empty", nameof(name));
        }
        var @event = new CategoryCreated(name, description, mimes);
        Apply(@event);
        AddUncommittedEvent(@event);
    }

    private Category() { }
    
    public override string ToString()
    {
        return $"{this.Id};{this.Name};{this.Description};{this.GetMimesAsString()};{this.GetTagsAsString()}";
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return;
        }
        this.Name = name;
    }
    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            return;
        }
        this.Description = description;
    }

    public void Update()
    {
        var categoryModified = new CategoryModified(this.Id, this.Name, this.Description, this.Mimes, this.Tags);
        Apply(categoryModified);
        AddUncommittedEvent(categoryModified);
    }
    
    public void AddMimes(List<string>? mimes)
    {
        mimes!.ForEach(mime => { this.Mimes.Add(mime); });
    }

    public void AddTags(Dictionary<string, List<string>>? tags)
    {
        if (tags != null) this.Tags = new Dictionary<string, List<string>>(tags);
    }

    private void Apply(CategoryCreated @event)
    {
        Id = @event.Guid; 
        Name = @event.Name;
        Mimes = @event.Mimes;
        Description = @event.Description;
        Version++;
    }

    private void Apply(CategoryModified @event)
    {
        Name = @event.Name;
        Mimes = @event.Mimes ?? Mimes;
        Tags = @event.Tags ?? Tags;
        Description = @event.Description;
        Version++;
    }

    public string GetMimesAsString()
    {
        return this.CollectionToString(this.Mimes);
    }

    public string GetTagsAsString()
    {
        return this.CollectionToString(this.Tags);
    }
}