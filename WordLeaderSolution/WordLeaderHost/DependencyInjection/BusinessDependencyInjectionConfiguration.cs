using Microsoft.Extensions.DependencyInjection;
using WordLadderBusiness.Contracts;
using WordLadderBusiness.Services;
using WordLadderBusiness.Services.Solvers;

namespace WordLadderHost.DependencyInjection
{
    internal static class BusinessDependencyInjectionConfiguration
    {
        internal static IServiceCollection LoadServices(IServiceCollection services)
        {
            return services.AddScoped<IWordLadderSolver, GraphWordLadderSolver>()
                           .AddScoped<IWordLadderRunner, WordLadderRunner>();
        }
    }
}
