using Newtonsoft.Json;
using Tiny.Cli.Misc;

namespace Tiny.Cli.Service;

public class CacheObjectManager
{
    private const string CacheResourceName = "Configuration.json";
    private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(3);

    private static ConfigurationObject? _configurationObject;
    public static ConfigurationObject ConfigurationObject
    {
        get
        {
            if (_configurationObject is not null) return _configurationObject;
            
            var jsonString = File.ReadAllText(CacheResourceName);
            _configurationObject = JsonConvert.DeserializeObject<ConfigurationObject>(jsonString) ??
                                   throw new InvalidOperationException();

            return _configurationObject;
        } 
    }

    public Task<bool> CacheExpired()
    {
        return Task.FromResult(DateTime.Now - ConfigurationObject.LastUpdateCheck > _cacheDuration);
    }
    
    public async Task UpdateCache()
    {
        var jsonString = JsonConvert.SerializeObject(ConfigurationObject);
        
        await using Stream? stream = File.OpenWrite(CacheResourceName);
        await using var writer = new StreamWriter(stream ?? throw new InvalidOperationException());
        await writer.WriteAsync(jsonString);
    }
}