using Pika.Domain.Storage.Callables.ValueTypes;

namespace Pika.Domain.Storage.Callables;
public abstract class BaseJobCallable
{
    public abstract Task Execute(Dictionary<string, ParameterValueType>? parameterValueTypes);
}