using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiny.Cli.Misc;
using Tiny.Cli.Service;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<EnvironmentWrapper>();
builder.Services.AddSingleton<VersionService>();
builder.Services.InstallArgumentValidators();
builder.Services.AddSingleton<ArgumentValidationService>();
builder.Services.AddSingleton<TinifyWorkFlowProcessor>();
builder.Services.AddSingleton<TinifyProcessingService>();
var host = builder.Build();

var version = host.Services.GetRequiredService<VersionService>();
await version.CheckAndUpdateVersion();

var service = host.Services.GetRequiredService<TinifyProcessingService>();
await service.Process(args);