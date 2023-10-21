﻿using Tiny.Cli.Validation;

namespace Tiny.Cli;

public class ArgumentValidationService
{
    private readonly IEnumerable<IArgumentValidator> _validators;
    public ArgumentValidationService(IEnumerable<IArgumentValidator> validators)
    {
        _validators = validators;
    }
    public bool ValidateArguments(string[] arguments)
    {
        var argumentsAreValid = true;
        foreach (var validator in _validators)
        {
            //ParseArguments Methode
            //GetResult Methode
            //ValidationResult Objekt
            //ValidationError Property
            validator.ValidateArguments(arguments);
            if (!validator.IsValid)
            {
                argumentsAreValid = false;
            }
        }

        _validators.Select(v => v.Message)
            .Where(v => v != null)
            .ToList()
            .ForEach(Console.WriteLine);
        
        return argumentsAreValid;
    }
}