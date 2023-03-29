using Marten.Events.Projections;
using Pika.Domain.Storage.Entity.Event;
using Pika.Domain.Storage.Entity.View;

namespace Pika.Domain.Storage.Entity.Projection;

public class BucketsProjection : MultiStreamAggregation<BucketsView, Guid>
{
    public BucketsProjection()
    {
        Identity<Bucket>(b => b.Id);
        Identity<BucketCreated>(bc => bc.Id);
        Identity<BucketModified>(bc => bc.Id);
    }

    public void Apply(BucketCreated bucketCreated, BucketsView view)
    {
        view.Id = bucketCreated.Id;
        view.Name = bucketCreated.Name;
        view.RoleClaims = bucketCreated.RoleClaims;
    }
    
    public void Apply(BucketModified bucketCreated, BucketsView view)
    {
        view.Id = bucketCreated.Id;
        view.Name = bucketCreated.Name;
        view.RoleClaims.AddRange(bucketCreated.RoleClaims.Distinct());
        view.RoleClaims = view.RoleClaims.Distinct().ToList();
    }
}