using System.Linq.Expressions;
using Marten.Linq;

namespace Pika.Domain.Storage.Entity.Queries;

public class FindBucketByName : ICompiledQuery<Bucket, Bucket>
{
    public string BucketName { get; set; }
    
    public Expression<Func<IMartenQueryable<Bucket>, Bucket>> QueryIs()
    {
        return q => q.First(b => b.Name == BucketName);
    }
}