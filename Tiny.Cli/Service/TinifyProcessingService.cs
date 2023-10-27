﻿using Tiny.Cli.Misc;

namespace Tiny.Cli.Service;

public class TinifyProcessingService
{
    private readonly ArgumentValidationService _argumentValidationService;
    private readonly TinifyWorkFlowProcessor _tinifyWorkFlowProcessor;

    public TinifyProcessingService(ArgumentValidationService argumentValidationService, TinifyWorkFlowProcessor tinifyWorkFlowProcessor)
    {
        _argumentValidationService = argumentValidationService;
        _tinifyWorkFlowProcessor = tinifyWorkFlowProcessor;
    }
    
    public async Task Process(string[] arguments)
    {
        try
        {
            var workFlowParameters = _argumentValidationService.ValidateArgumentsAndParseParameters(arguments);
            await _tinifyWorkFlowProcessor.Run(workFlowParameters);
        }
        catch (InvalidParametersException)
        {
        }
        catch (NoArgumentsProvidedException)
        {
            Console.WriteLine($"No arguments provided, type tiny {Parameter.Help.Simple} for more information.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}