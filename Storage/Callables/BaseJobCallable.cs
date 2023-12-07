using Microsoft.Extensions.Caching.Distributed;
using Pika.Domain.Storage.Callables.ValueTypes;

namespace Pika.Domain.Storage.Callables;
public abstract class BaseJobCallable
{
    private readonly IDistributedCache? _cache;
    
    protected BaseJobCallable(){}
    
    protected BaseJobCallable(IDistributedCache distributedCache)
    {
        this._cache = distributedCache;
    }
    public abstract Task Execute(Dictionary<string, ParameterValueType>? parameterValueTypes);

    protected async Task<bool> IsJobRunningOnMaster()
    {
        if (_cache == null)
        {
            throw new InvalidOperationException("Cannot determine whether the job is running on master or not!");
        }
        var host = await _cache.GetStringAsync("MasterHost") ?? null;
        return !string.IsNullOrEmpty(host) && host.Equals(Environment.GetEnvironmentVariable("HOSTNAME"));
    }
}