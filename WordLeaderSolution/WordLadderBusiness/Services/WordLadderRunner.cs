using WordLadderBusiness.Contracts;
using WordLadderDomain.Exceptions;
using WordLadderDomain.Repositories;
using WordLadderDomain.Services;

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

        public async Task RunAsync(string startWord, string endWord, CancellationToken token)
        {
            var dictionary = await dictionaryRepository.LoadDictionaryAsync();

            try
            {
                var t = new GraphRunner();
                var result = t.BuildGraph(startWord.ToUpper(), endWord.ToUpper(), dictionary);
                
                //var f = new WordLadderCalculatorV2();
                //var result = f.CalculateFastestPath(startWord.ToUpper(), endWord.ToUpper(), dictionary);

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
    }
}
