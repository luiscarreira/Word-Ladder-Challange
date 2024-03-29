﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordLadderHost.DependencyInjection;

namespace WordLadderHost
{
    public static class WordLadderHostBuilder
    {
        private static string _dictionaryPath = string.Empty;
        private static string _resultPath = string.Empty;

        /// <summary>
        /// Provides a method that configures and builds the Host used in this project.
        /// </summary>
        /// <remarks>
        /// Loads information from settings files and environment variables. Adds logging and register services with
        /// their appropriate lifetime.
        /// </remarks>
        /// <param name="args">Command line arguments passed when program is executed.</param>
        /// <returns>An initialized IHost.</returns>
        public static IHost Build(string[] args, string dictionaryPath, string resultPath)
        {
            _dictionaryPath = dictionaryPath;
            _resultPath = resultPath;

            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            AddConfiguration(builder, args);
            AddServices(builder);

            builder.UseConsoleLifetime();
            builder.ConfigureServices(s => s.BuildServiceProvider());

            return builder.Build();
        }

        /// <summary>
        /// Add configuration files and environment variables to the HostBuilder.
        /// </summary>
        /// <param name="hostBuilder">Shared HostBuilder under configuration.</param>
        /// <param name="args">Command line arguments passed when program is executed.</param>
        private static void AddConfiguration(IHostBuilder hostBuilder, string[] args) =>
          hostBuilder.ConfigureAppConfiguration(builder =>
          {
              builder
              .AddJsonFile("appsettings.json", false, true)
              .AddCommandLine(args);
          });

        /// <summary>
        /// Registers concrete implementations of services used by the application.
        /// </summary>
        /// <param name="hostBuilder">Shared HostBuilder under configuration.</param>
        private static void AddServices(IHostBuilder hostBuilder) =>
          hostBuilder
            .ConfigureServices(services =>
            {
                FileSystemInfrastructureDependecyInjectionConfiguration.LoadServices(services, _dictionaryPath, _resultPath);
                BusinessDependencyInjectionConfiguration.LoadServices(services);
            });
    }
}
