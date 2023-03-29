using System.Linq.Expressions;
using Marten.Linq;

namespace Pika.Domain.Storage.Entity.Queries;

public class GetAllCategories : ICompiledQuery<Category, IEnumerable<Category>>
{
    public Expression<Func<IMartenQueryable<Category>, IEnumerable<Category>>> QueryIs()
    {
        var ct = new CancellationToken();
        return q => q.ToListAsync<Category>(ct).Result;
    }
}