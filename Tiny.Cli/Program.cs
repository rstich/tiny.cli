﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiny.Cli.Misc;
using Tiny.Cli.Service;

var builder = Host.CreateApplicationBuilder();
builder.Services.InstallArgumentValidators();
builder.Services.AddSingleton<ArgumentValidationService>();
builder.Services.AddSingleton<TinifyWorkFlowService>();
builder.Services.AddSingleton<TinifyProcessingService>();
var host = builder.Build();

var service = host.Services.GetRequiredService<TinifyProcessingService>();
service.Process(args);