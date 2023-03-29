namespace Pika.Domain.Storage.Entity.Event;

public class BucketCreated
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> RoleClaims { get; set; }

    public BucketCreated(string name, List<string> roleClaims)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.RoleClaims = roleClaims;
    }
}