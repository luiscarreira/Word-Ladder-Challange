using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordLadderBusiness.Contracts;
using WordLadderHost.Data;

namespace WordLadderHost
{
    internal static class WordLadderScopedExecution
    {
        internal static async Task Execute(string[] args, ArgumentsDto argumentsDto)
        {
            IHost? host = default;
            CancellationTokenSource cancellationTokenSource = new();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            try
            {
                host = WordLadderHostBuilder.Build(args, argumentsDto.DictionaryPath, argumentsDto.ResultPath);
                await host.StartAsync(cancellationToken).ConfigureAwait(false);

                // A scope is required so that Runner class can use scoped lifetime services.
                await using (AsyncServiceScope scope = host.Services.CreateAsyncScope())
                {
                    // Main logic of the app is in "RunAsync" method of "Runner" instance.
                    var runner = ActivatorUtilities.GetServiceOrCreateInstance<IWordLadderRunner>(scope.ServiceProvider);
                    var solver = ActivatorUtilities.GetServiceOrCreateInstance<IWordLadderSolver>(scope.ServiceProvider);
                    await runner.RunAsync(solver, argumentsDto.StartWord, argumentsDto.EndWord, argumentsDto.MaxWordLenght, cancellationToken);

                    Console.WriteLine();
                    Console.WriteLine("Press any key to close.");
                    Console.ReadKey();
                    cancellationTokenSource.Cancel();
                }

                await host.WaitForShutdownAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                Console.Write("\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}. {Environment.NewLine}{ex.StackTrace}");
            }
            finally
            {
                cancellationTokenSource?.Dispose();

                if (host is IAsyncDisposable disposableHost)
                {
                    await disposableHost.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
