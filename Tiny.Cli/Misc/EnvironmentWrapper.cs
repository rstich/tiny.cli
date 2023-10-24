namespace Tiny.Cli.Misc;

public class EnvironmentWrapper
{
    public static readonly string ApiKey = "TINY_KEY";
    public virtual string? GetEnvironmentVariable()
    {
        return Environment.GetEnvironmentVariable(ApiKey);
    }
}