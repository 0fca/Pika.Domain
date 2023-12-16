using Marten;
using Marten.Linq;
using Pika.Domain.Storage.Entity;

namespace Pika.Domain.Storage.Repository;

public class AggregateRepository
{
    private readonly IDocumentStore _store;

    public AggregateRepository(IDocumentStore store)
    {
        this._store = store;
    }

    public async Task StoreAsync(AggregateBase aggregate, CancellationToken ct = default)
    {
        await using var session = _store.LightweightSession();
        var events = aggregate.GetUncommittedEvents().ToArray();
        session.Events.Append(aggregate.Id, aggregate.Version, events);
        await session.SaveChangesAsync(ct);
        aggregate.ClearUncommittedEvents();
    }

    public async Task<T> LoadAsync<T>(
        Guid id,
        int? version = null,
        CancellationToken ct = default
    ) where T : AggregateBase
    {
        await using var session = _store.LightweightSession();
        var aggregate = await session.Events.AggregateStreamAsync<T>(id, version ?? 0, token: ct);
        return aggregate ?? throw new InvalidOperationException($"No aggregate by id {id}.");
    }

    public async Task<Guid> Archive<T>(Guid id, CancellationToken ct = default) where T : AggregateBase
    {
        await using var session = _store.LightweightSession();
        session.Events.ArchiveStream(id);
        await session.SaveChangesAsync(ct);
        return id;
    }
}