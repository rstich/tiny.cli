using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiny.Cli;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Services.InstallArgumentValidators();
builder.Services.AddSingleton<ArgumentValidationService>();
builder.Services.AddSingleton<TinifyProcessingService>();
var host = builder.Build();

var service = host.Services.GetRequiredService<TinifyProcessingService>();
service.Process(args);



