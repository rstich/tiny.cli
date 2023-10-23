using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace Tiny.Cli.Service;

public class ArgumentValidationService
{
    private readonly IEnumerable<IArgumentValidator> _validators;
    public ArgumentValidationService(IEnumerable<IArgumentValidator> validators)
    {
        _validators = validators;
    }
    public WorkFlowParameters ValidateArgumentsAndParseParameters(string[] arguments)
    {
        WorkFlowParameters parameters = new();
        var argumentsAreValid = true;
        foreach (var validator in _validators)
        {
            validator.ValidateArguments(arguments, parameters);
            if (!validator.IsValid)
            {
                argumentsAreValid = false;
            }
        }

        _validators.Select(v => v.Message)
            .Where(v => v != null)
            .ToList()
            .ForEach(Console.WriteLine);

        if (!argumentsAreValid) throw new InvalidParametersException();
        
        // has to move to the validator, no actual validation code here
        if (parameters.FilePath is not null && parameters.Directory is not null) throw new InvalidParametersException("There cant be both parameters for file and directory");
        if (parameters.FilePath is null && parameters.Directory is null) throw new InvalidParametersException("There has to be a file, directory or the current directory");
        
        return parameters;
    }
}