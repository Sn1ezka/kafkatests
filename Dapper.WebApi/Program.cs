using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Dapper.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .UseSerilog(configureLogger: (context, configuration) =>
                        {
                            configuration.Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(
                           new ElasticsearchSinkOptions(node: new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                                    {
                                        IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{ context.HostingEnvironment.EnvironmentName?.ToLower().Replace(oldValue: ".", newValue: "-")}-{ DateTime.UtcNow:yyyy-MM}",
                                        AutoRegisterTemplate = true,
                                        NumberOfShards = 2,
                                        NumberOfReplicas = 1
                                    })//Logger configuration
                        .Enrich.WithProperty(name: "Environment", context.HostingEnvironment.EnvironmentName)//LoggerEnrichmentConfiguration
                        .ReadFrom.Configuration(context.Configuration);
                        })
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                        });
    }
}