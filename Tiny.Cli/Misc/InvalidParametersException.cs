namespace Tiny.Cli.Misc;

public class InvalidParametersException : Exception
{
    public InvalidParametersException()
    {
    }
    public InvalidParametersException(string? message) : base(message) 
    {
    }
}