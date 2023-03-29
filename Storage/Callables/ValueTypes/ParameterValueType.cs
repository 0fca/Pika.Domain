using System.Text.Json;

namespace Pika.Domain.Storage.Callables.ValueTypes;

public class ParameterValueType
{
    public string _value;

    public ParameterValueType(object value)
    {
        this._value = JsonSerializer.Serialize(value);
    }
    
    public T Value<T>()
    {
        return JsonSerializer.Deserialize<T>(this._value);
    }

    public object GetValue()
    {
        return this._value;
    }
}