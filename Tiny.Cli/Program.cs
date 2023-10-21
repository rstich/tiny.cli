using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp;
using TinifyAPI;
using Tiny.Cli;
using Tiny.Cli.Validation;


ValidateEnvironmentVariables();

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Services.InstallArgumentValidators();
builder.Services.AddSingleton<ArgumentValidationService>();
builder.Services.AddSingleton<TinifyProcessingService>();
var host = builder.Build();

var service = host.Services.GetRequiredService<TinifyProcessingService>();
service.Process(args);

//maybe this in the main class too or also in a validator?
static void ValidateEnvironmentVariables()
{
    var tinyKey = Environment.GetEnvironmentVariable("TINY_KEY");

    if (tinyKey is null)
    {
        Console.WriteLine("Please set the TINY_KEY environment variable by typing:");
        Console.WriteLine("set TINY_KEY=your_api_key");
        return;
    }

    Tinify.Key = tinyKey; // Your API key
}


