using System.Linq.Expressions;
using Marten.Linq;
using Pika.Domain.Storage.Entity.Event;

namespace Pika.Domain.Storage.Entity.Queries;

public class GetAllBuckets : ICompiledQuery<Bucket, IEnumerable<Bucket>>
{
    public Expression<Func<IMartenQueryable<Bucket>, IEnumerable<Bucket>>> QueryIs()
    {
        var ct = new CancellationToken();
        return q => q.ToListAsync<Bucket>(ct).Result;
    }
}