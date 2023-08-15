using Marten.Events.Projections;
using Pika.Domain.Storage.Entity.Event;
using Pika.Domain.Storage.Entity.View;

namespace Pika.Domain.Storage.Entity.Projection;

public class CommandsProjection : MultiStreamAggregation<CommandsView, Guid>
{
    public CommandsProjection()
    {
        Identity<Command>(b => b.Id);
        Identity<CommandCreated>(b => b.Id);
    }

    public void Apply(CommandCreated @event, CommandsView view)
    {
        view.Id = @event.Id;
        view.Body = @event.Body;
        view.Headers = @event.Headers;
        view.Name = @event.Name;
    }
}