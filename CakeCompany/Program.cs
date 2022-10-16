// See https://aka.ms/new-console-template for more information
using Autofac;
using CakeCompany.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

//Registering autofac setup
var container = ContainerConfig.Configure();
using(var scope = container.BeginLifetimeScope())
{
    var app = scope.Resolve<IApplication>();
    Log.Information("Configuration for autofac and serilog started ");
    app.Run();
    
}
//Configuring logger
var builder = new ConfigurationBuilder();
BuildConfig(builder);
var filepath = Path.Combine(Directory.GetCurrentDirectory(), "LogFile.txt");
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(filepath,rollingInterval:RollingInterval.Day)
    .CreateLogger();
Log.Logger.Information("Application started...");



static void BuildConfig(IConfigurationBuilder builder)
 {
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();
}