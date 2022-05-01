using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLadderDomain.Models;

namespace WordLadderDomain.Services
{
    public class WordLadderCalculator
    {
        public WordPath CalculateFastestPath(string startWord, string endWord, WordLadderDictionary dictionary)
        {
            var result = new WordPath();

            result.Words.Add(new Word(startWord, NumberOfSameCharsBetweenWordsOfSameSize(startWord, endWord)));

            result = Calculate(startWord, endWord, dictionary, result);

            return result;
        }

        private WordPath Calculate(string fromWord, string toWord, WordLadderDictionary dictionary, WordPath path)
        {
            if (fromWord == toWord)
            {
                return path;
            }

            var words = GetWordsFromDictionaryThatDiffersOnlyOneLetter(fromWord, dictionary, path.Words.Select(x => x.Value).ToList());

            var bestWord = string.Empty;
            var bestScore = 0;
            foreach (var word in words)
            {
                var score = NumberOfSameCharsBetweenWordsOfSameSize(word, toWord);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestWord = word;
                }
            }

            path.Words.Add(new Word(bestWord, bestScore));
            return Calculate(bestWord, toWord, dictionary, path);
        }


        private IReadOnlyList<string> GetWordsFromDictionaryThatDiffersOnlyOneLetter(
            string word, 
            WordLadderDictionary dictionary,
            List<string> excludedWords)
        {
            var result = new List<string>();
            foreach(string dictionaryWord in dictionary.DictionaryEntries)
            {
                if (excludedWords.Contains(dictionaryWord))
                {
                    continue;
                }

                var numberOfChanges = NumberOfDifferentCharsBetweenWordsOfSameSize(word, dictionaryWord);
                if(numberOfChanges == 1)
                {
                    result.Add(dictionaryWord);
                }
            }
            return result;
        }

        private int NumberOfDifferentCharsBetweenWordsOfSameSize(string wordA, string wordB)
        {
            var counter = 0;
            if(wordA.Length != wordB.Length)
            {
                return Int32.MaxValue;
            }

            for(int i = 0; i<wordA.Length; i++)
            {
                if(wordA[i] != wordB[i])
                {
                    counter++;
                }
            }

            return counter;
        }

        private int NumberOfSameCharsBetweenWordsOfSameSize(string wordA, string wordB)
        {
            var counter = 0;
            if (wordA.Length != wordB.Length)
            {
                return Int32.MinValue;
            }

            for (int i = 0; i < wordA.Length; i++)
            {
                if (wordA[i] == wordB[i])
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
