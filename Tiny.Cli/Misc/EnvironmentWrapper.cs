namespace Tiny.Cli.Misc;

public class EnvironmentWrapper
{
    public static readonly string ApiKey = "TINY_KEY";
    public string? GetEnvironmentVariable()
    {
        return Environment.GetEnvironmentVariable(ApiKey);
    }
}