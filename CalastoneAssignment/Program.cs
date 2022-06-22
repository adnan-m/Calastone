using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Calastone.Service;

// Setup Host
var host = CreateDefaultBuilder().Build();

// Invoke Worker
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
var dataProcessor = provider.GetRequiredService<TextProcessor>();
dataProcessor.ProcessText();

host.Run();


static IHostBuilder CreateDefaultBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(app =>
        {
            app.AddJsonFile("appsettings.json");
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton<TextProcessor>();
            services.AddTransient<ITextReader, Calastone.Service.TextReader>();            
            services.AddTransient<ITextFilterService, TextFilterService>();
        });
}
