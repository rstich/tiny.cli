﻿using TinifyAPI;
using Tiny.Cli.Misc;

namespace Tiny.Cli.Service;

public class TinifyProcessingService
{
    private readonly ArgumentValidationService _argumentValidationService;
    private readonly TinifyWorkFlowService _tinifyWorkFlowService;

    public TinifyProcessingService(ArgumentValidationService argumentValidationService, TinifyWorkFlowService tinifyWorkFlowService)
    {
        _argumentValidationService = argumentValidationService;
        _tinifyWorkFlowService = tinifyWorkFlowService;
    }
    
    public void Process(string[] arguments)
    {
        if (!EnvironmentSettingValid()) return;

        try
        {
            var workFlowParameters = _argumentValidationService.ValidateArgumentsAndParseParameters(arguments);
            _tinifyWorkFlowService.Run(workFlowParameters);
        }
        catch (InvalidParametersException e)
        {
            Console.WriteLine("Invalid parameters");
        }
    }

    private static bool EnvironmentSettingValid()
    {
        var tinyKey = Environment.GetEnvironmentVariable("TINY_KEY");

        if (tinyKey is null)
        {
            Console.WriteLine("Please set the TINY_KEY environment variable by typing:");
            Console.WriteLine("set TINY_KEY=your_api_key");
            return false;
        }

        Tinify.Key = tinyKey; // Your API key4
        return true;
    }
}