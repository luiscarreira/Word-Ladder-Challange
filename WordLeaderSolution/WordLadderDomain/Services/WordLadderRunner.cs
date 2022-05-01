using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLadderDomain.Repositories;

namespace WordLadderDomain.Services
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

            var f = new WordLadderCalculator();
            var result = f.CalculateFastestPath(startWord.ToUpper(), endWord.ToUpper(), dictionary);

            await pathRepository.PersistPathAsync(result);
        }
    }
}
