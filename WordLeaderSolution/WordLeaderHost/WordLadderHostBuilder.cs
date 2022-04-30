using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLadderDomain.Repositories;
using WordLadderFileSystemInfrastructure.Repositories;

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
            //Guard.Against.Null(args, nameof(args));
            _dictionaryPath = dictionaryPath;
            _resultPath = resultPath;

            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            //AddConfiguration(builder, args);
            //AddLogging(builder);
            //AddOptions(builder);
            AddServices(builder);

            builder.UseConsoleLifetime();
            builder.ConfigureServices(s => s.BuildServiceProvider());

            return builder.Build();
        }

        /// <summary>
        /// Registers concrete implementations of services used by the application.
        /// </summary>
        /// <param name="hostBuilder">Shared HostBuilder under configuration.</param>
        private static void AddServices(IHostBuilder hostBuilder) =>
          hostBuilder
            .ConfigureServices(services =>
            {
                services.AddScoped<IDictionaryRepository, DictionaryRepository>(x => new DictionaryRepository(_dictionaryPath));
                services.AddScoped<IPathRepository, PathRepository>(x => new PathRepository(_resultPath));                
            });
    }
}
