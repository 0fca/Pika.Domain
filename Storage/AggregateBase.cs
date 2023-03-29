﻿using System.Text.Json.Serialization;

namespace Pika.Domain.Storage;

public class AggregateBase
{
    public Guid Id { get; protected set; }

    public long Version { get; set; }

    [JsonIgnore] private readonly List<object> _uncommittedEvents = new List<object>();

    public IEnumerable<object> GetUncommittedEvents()
    {
        return _uncommittedEvents;
    }

    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }

    protected void AddUncommittedEvent(object @event)
    {
        _uncommittedEvents.Add(@event);
    } 
}