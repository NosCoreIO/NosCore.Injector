using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bleak;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NosCore.Shared.Configuration;
using NosCore.Shared.I18N;
using Serilog;

namespace NosCore.Injector
{
    public class Program
    {
        private const string Title = "NosCore - Injector";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var injectorConfiguration = new InjectorConfiguration();
            try { Console.Title = Title; } catch (PlatformNotSupportedException) { }
            var configuration = ConfiguratorBuilder.InitializeConfiguration(args, new[] { "injector.yml", "logger.yml" });

            LogLanguage.Language = injectorConfiguration.Language;

            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(
                    loggingBuilder =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddSerilog(dispose: true);
                    }
                )
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions<InjectorConfiguration>().Bind(configuration);
                    services.AddHostedService<Worker>();
                });
        }
    }

    public class Worker : BackgroundService
    {
        private const string ConsoleText = "Injector - NosCoreIO";
        private readonly InjectorConfiguration _configuration;
        private readonly ILogger<Worker> _logger;

        public Worker(IOptions<InjectorConfiguration> configuration, ILogger<Worker> logger)
        {
            _configuration = configuration.Value;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.PrintHeader(ConsoleText);
            var injectors = new Dictionary<int, Bleak.Injector>();
            while (!stoppingToken.IsCancellationRequested)
            {
                Process[] processlist = Process.GetProcessesByName(_configuration.ExecutableName);
                foreach (var process in processlist.Where(o=>!injectors.ContainsKey(o.Id)))
                {
                    _logger.LogInformation(LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INJECTING_PID),
                        process.Id);
                    var injector = new Bleak.Injector(process.Id, _configuration.PacketLoggerDllPath,
                        InjectionMethod.CreateThread);
                    injector.InjectDll();
                    injectors.Add(process.Id, injector);
                    _logger.LogInformation(LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INJECTED_PID), process.Id);
                }

                await Task.Delay(1000, stoppingToken);
            }

            foreach (var injector in injectors.Values)
            {
                injector.EjectDll();
            }
        }
    }
}
