namespace Tiny.Cli.Validation;

public abstract class BaseValidator
{
    protected bool ContainsValidatorArgument(string[] arguments, string simple, string complex)
    {
        return arguments.Contains(simple) || arguments.Contains(complex);
    }
    protected bool TooManyValidatorArgumentsProvided(string[] arguments, string firstArgument, string secondArgument)
    {
        if (arguments.Count(s => s.Contains(firstArgument)) <= 1 && arguments.Count(s => s.Contains(secondArgument)) <= 1)
            return false;
        
        return true;
    }

    protected bool BothValidatorArgumentsProvided(string[] arguments, string firstArgument, string secondArgument)
    {
        if (arguments.Contains(firstArgument) && arguments.Contains(secondArgument))
        {
            return true;
        }

        return false;
    }
}