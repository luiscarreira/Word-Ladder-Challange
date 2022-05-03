using QuikGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordLadderDomain.Models;

namespace WordLadderBusiness.Services
{
    public  class GraphRunner
    {
        private Regex OnlyLettersRegEx = new("^[a-zA-Z]*$");
        private List<string> VisitedWords = new List<string>();

        private Queue<string> WordsQueue = new Queue<string>();

        private BidirectionalGraph<string, Edge<string>> graph = new BidirectionalGraph<string, Edge<string>>();

        public WordPath BuildGraph(string startWord, string endWord, WordLadderDictionary dictionary)
        {
            WordsQueue.Enqueue(startWord);
            graph.AddVertex(startWord);

            while (WordsQueue.Count > 0)
            {
                var word = WordsQueue.Dequeue();
                Calculate(word, endWord, dictionary);
            }


            WordPath result = new WordPath();
            result.Words.AddRange((IEnumerable<Word>)GetPath(startWord, endWord));

            return result;
        }

        private List<string> GetPath(string startWord, string endWord)
        {
            var result = new List<string>();

            var goalVertice = graph.Vertices.FirstOrDefault(x => x == endWord);
            //var root = endWord;
            while(goalVertice != startWord)
            {
                result.Add(goalVertice);
                var edge = graph.InEdge(goalVertice, 0);
                goalVertice = edge.GetOtherVertex(goalVertice);
            }

            result.Add(startWord);
            result.Reverse();

            return result;
        }

        private void Calculate(string fromWord, string toWord, WordLadderDictionary dictionary)
        {
            var words = GetWordsFromDictionaryThatDiffersOnlyOneLetter(fromWord, dictionary, VisitedWords);

            foreach (string word in words)
            {
                graph.AddVertex(word);
                graph.AddEdge(new Edge<string>(fromWord, word));

                if (word.Equals(toWord))
                {
                    WordsQueue.Clear();
                    break;
                }

                WordsQueue.Enqueue(word);
            }
            VisitedWords.Add(fromWord);
        }

        private IReadOnlyList<string> GetWordsFromDictionaryThatDiffersOnlyOneLetter(
            string word,
            WordLadderDictionary dictionary,
            List<string> excludedWords)
        {
            var result = new List<string>();

            foreach (string dictionaryWord in dictionary.DictionaryEntries.Except(excludedWords))
            {
                var numberOfChanges = dictionaryWord.Length - CountNumberOfMacthingChars(word, dictionaryWord);
                if (numberOfChanges == 1)
                {
                    result.Add(dictionaryWord);
                }
            }
            return result;
        }

        private int CountNumberOfMacthingChars(string wordA, string wordB)
        {
            int result = 0;
            if (wordA.Length == wordB.Length)
            {
                result = wordA.Where((x, i) => x.Equals(wordB[i])).Count();
            }

            return result;
        }
    }
}
