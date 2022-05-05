using WordLadderBusiness.Contracts;
using WordLadderDomain.Exceptions;
using WordLadderDomain.Models;
using WordLadderDomain.Repositories;

namespace WordLadderBusiness.Services
{
    public class WordLadderRunner : IWordLadderRunner
    {
        private readonly IDictionaryRepository dictionaryRepository;
        private readonly IPathRepository pathRepository;

        public WordLadderRunner(IDictionaryRepository dictionaryRepository, IPathRepository pathRepository)
        {
            this.dictionaryRepository = dictionaryRepository;
            this.pathRepository = pathRepository;
        }

        /// <inheritdoc/>
        public async Task RunAsync(IWordLadderSolver solver, string startString, string endString, int maxWordLenghtAllowed, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var dictionary = await dictionaryRepository.LoadDictionaryAsync(maxWordLenghtAllowed);

            try
            {
                Word startWord = new Word(startString);
                Word endWord = new Word(endString);
                var result = solver.SolveWordLadder(startWord, endWord, dictionary);

                if (result != null)
                {
                    await pathRepository.PersistPathAsync(result);
                    Console.WriteLine("Path Calculated and saved.");
                }
                else
                {
                    Console.WriteLine("ERROR: No Ladder to persist.");
                }
            }
            catch (Exception ex) when (ex.GetType() == typeof(ArgumentException) || ex.GetType() == typeof(NoWordLadderFoundException))
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            
        }

        /// <inheritdoc/>
        public async Task RunAsync(IWordLadderSolver solver, string startString, string endString, CancellationToken token)
        {
            await RunAsync(solver, startString, endString, Int32.MaxValue, token);
        }
    }
}
