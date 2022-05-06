using Microsoft.Extensions.DependencyInjection;
using WordLadderDomain.Repositories;
using WordLadderFileSystemInfrastructure.Repositories;

namespace WordLadderHost.DependencyInjection
{
    internal static class FileSystemInfrastructureDependecyInjectionConfiguration
    {
        internal static IServiceCollection LoadServices(IServiceCollection services, string dictionaryPath, string resultPath)
        {
            return services.AddScoped<IDictionaryRepository, DictionaryRepository>(x => new DictionaryRepository(dictionaryPath))
                           .AddScoped<IPathRepository, PathRepository>(x => new PathRepository(resultPath));
        }
    }
}
