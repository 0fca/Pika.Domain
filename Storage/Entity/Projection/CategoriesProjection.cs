using System.Data;
using Marten.Events.Projections;
using Pika.Domain.Storage.Entity.Event;
using Pika.Domain.Storage.Entity.View;

namespace Pika.Domain.Storage.Entity.Projection;

public class CategoriesProjection : MultiStreamAggregation<CategoriesView, Guid>
{
    public CategoriesProjection()
    {
        Identity<Category>(b => b.Id);
        Identity<CategoryCreated>(bc => bc.Guid);
        Identity<CategoryModified>(bc => bc.Id);
    }

    public void Apply(CategoryCreated bucketCreated, CategoriesView view)
    {
        view.Id = bucketCreated.Guid;
        view.Name = bucketCreated.Name;
        view.Description = bucketCreated.Description;
        view.Tags = bucketCreated.Tags;
        view.Mimes = bucketCreated.Mimes;
    }
    
    public void Apply(CategoryModified bucketCreated, CategoriesView view)
    {
        view.Id = bucketCreated.Id;
        view.Name = bucketCreated.Name;
        view.Description = bucketCreated.Description;
        view.Tags = bucketCreated.Tags;
        view.Mimes = bucketCreated.Mimes;
    }
}