using WordLadderDomain.Exceptions;
using WordLadderDomain.Models;

namespace WordLadderDomain.Services
{
    public class WordLadderCalculatorV2
    {
        private readonly WordBucketService _wordBucketService;


        public WordLadderCalculatorV2()
        {
            _wordBucketService = new WordBucketService();
        }

        public WordPath CalculateFastestPath(string startWord, string endWord, WordLadderDictionary dictionary)
        {
            //Verifications
            if(startWord.Length != endWord.Length)
            {
                throw new ArgumentException("Start and End words must have the same size.");
            }

            if (!dictionary.ContainsWord(startWord))
            {
                throw new ArgumentException("Start word does not exist on dictionary.");
            }

            if (!dictionary.ContainsWord(endWord))
            {
                throw new ArgumentException("End word does not exist on dictionary.");
            }

            _wordBucketService.GenerateWordBucketsForWordsWithOnlyLetters(dictionary, startWord.Length);

            var startBuckets = _wordBucketService.GetMatchingBucketsForWord(new Word(startWord));






            var result = new WordPath();

            //result.Words.Add(new Word(startWord, CountNumberOfMacthingChars(startWord, endWord)));

            result = Calculate(startWord, endWord, dictionary, result);

            return result;
        }

        private WordPath? Calculate(string fromWord, string toWord, WordLadderDictionary dictionary, WordPath path)
        {
            if (fromWord == toWord)
            {
                return path;
            }

            var words = GetWordsFromDictionaryThatDiffersOnlyOneLetter(fromWord, dictionary, path.Words.Select(x => x.Value).ToList());

            if(words.Count == 0)
            {
                return null;
                //End of dictionary
                //throw new NoWordLadderFoundException("No path found between Start and End words using the current dictionary.");
            }

            //Choose the best words in each iteration from dictionary (the one closest to the goal word)
            var bestWord = string.Empty;
            var bestScore = 0;

            foreach (var word in words)
            {
                var score = CountNumberOfMacthingChars(word, toWord);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestWord = word;
                }
            }

            //path.Words.Add(new Word(bestWord, bestScore));
            return Calculate(bestWord, toWord, dictionary, path);
        }


        private IReadOnlyList<string> GetWordsFromDictionaryThatDiffersOnlyOneLetter(
            string word, 
            WordLadderDictionary dictionary,
            List<string> excludedWords)
        {
            var result = new List<string>();

            foreach(string dictionaryWord in dictionary.DictionaryEntries.Except(excludedWords))
            {
                var numberOfChanges = dictionaryWord.Length - CountNumberOfMacthingChars(word, dictionaryWord);
                if(numberOfChanges == 1)
                {
                    result.Add(dictionaryWord);
                }
            }
            return result;
        }

        private int CountNumberOfMacthingChars(string wordA, string wordB)
        {
            int result = 0;
            if(wordA.Length == wordB.Length)
            {
                result = wordA.Where((x, i) => x.Equals(wordB[i])).Count();
            }

            return result;
        }
    }
}
