using WordLadderDomain.Exceptions;
using WordLadderDomain.Extentions;
using WordLadderDomain.Models;

namespace WordLadderDomain.Services
{
    public class WordLadderCalculator
    {
        public WordPath CalculateFastestPath(Word startWord, Word endWord, WordLadderDictionary dictionary)
        {
            //Verifications
            if(startWord.Value.Length != endWord.Value.Length)
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

            var result = new WordPath();

            result = Calculate(startWord, endWord, dictionary, result);

            return result;
        }

        private WordPath? Calculate(Word fromWord, Word toWord, WordLadderDictionary dictionary, WordPath path)
        {
            if (fromWord.IsEqual(toWord))
            {
                return path;
            }

            var words = dictionary.GetWordsThatDifferGivenNumberOfLetters(fromWord, 1, path.Words);

            if(words.Count == 0)
            {
                return null;
            }

            //Choose the best words in each iteration from dictionary (the one closest to the goal word)
            Word bestWord = new Word(String.Empty);
            var bestScore = 0;

            foreach (var word in words)
            {
                var score = word.NumberOfMacthingChars(toWord);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestWord = word;
                }
            }

            return Calculate(bestWord, toWord, dictionary, path);
        }
    }
}
