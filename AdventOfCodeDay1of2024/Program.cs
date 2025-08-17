// See https://aka.ms/new-console-template for more information

using AdventOfCodeDay1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder();
host.Services
    .AddHostedService<Service>()
    .AddTransient<DataReader>()
    .AddTransient<Solver>();


var app = host.Build();
await app.RunAsync();