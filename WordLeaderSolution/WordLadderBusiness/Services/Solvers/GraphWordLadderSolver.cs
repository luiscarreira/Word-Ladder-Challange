using QuikGraph;
using WordLadderBusiness.Contracts;
using WordLadderDomain.Models;
using WordLadderDomain.Extentions;
using WordLadderDomain.Comparers;

namespace WordLadderBusiness.Services.Solvers
{
    public class GraphWordLadderSolver : IWordLadderSolver
    {
        /// <summary>
        /// Collection of visited words while creating the graph
        /// </summary>
        private readonly List<Word> visitedWords = new List<Word>();

        /// <summary>
        /// Words waiting in queue to be processed, new words get enqueued at each level of processment
        /// </summary>
        private readonly Queue<Word> wordsQueue = new Queue<Word>();

        /// <summary>
        /// Graph constructed based on the dictionary and the start word
        /// </summary>
        private readonly BidirectionalGraph<Word, Edge<Word>> graph = new BidirectionalGraph<Word, Edge<Word>>();

        /// <inheritdoc/>
        public WordPath SolveWordLadder(Word startWord, Word endWord, WordLadderDictionary dictionary)
        {
            WordPath result = new();

            if (dictionary.ContainsWord(startWord) && dictionary.ContainsWord(endWord))
            {
                wordsQueue.Enqueue(startWord);
                graph.AddVertex(startWord);

                while (wordsQueue.Count > 0)
                {
                    var word = wordsQueue.Dequeue();
                    GenerateNextLevelOfNodes(word, endWord, dictionary);
                }

                result.AppendWordsToPath(GetPath(startWord, endWord));
            }

            return result;
        }

        /// <summary>
        /// Generate the next level of nodes in the graph for a given word
        /// </summary>
        /// <param name="fromWord">The Word from where the next level of nodes will be based</param>
        /// <param name="toWord">The goal Word of the Ladder</param>
        /// <param name="dictionary">The Dictionary to use</param>
        private void GenerateNextLevelOfNodes(Word fromWord, Word toWord, WordLadderDictionary dictionary)
        {
            var words = dictionary.GetWordsThatDifferGivenNumberOfLetters(fromWord, 1, visitedWords);

            foreach (Word word in words)
            {
                graph.AddVertex(word);
                graph.AddEdge(new Edge<Word>(fromWord, word));

                if (word.Equals(toWord))
                {
                    wordsQueue.Clear();
                    break;
                }

                if (!wordsQueue.Contains(word, new WordEqualityComparer()))
                {
                    wordsQueue.Enqueue(word);
                }
            }
            visitedWords.Add(fromWord);
        }

        /// <summary>
        /// Extracts the shortest path between start and end Words from the graph
        /// </summary>
        /// <param name="startWord">The start word</param>
        /// <param name="endWord">The end word</param>
        /// <returns></returns>
        private List<Word> GetPath(Word startWord, Word endWord)
        {
            var result = new List<Word>();

            var goalVertice = graph.Vertices.FirstOrDefault(x => x.Equals(endWord));

            if (goalVertice != null)
            {
                while (!goalVertice.Equals(startWord))
                {
                    result.Add(goalVertice);
                    var edge = graph.InEdge(goalVertice, 0);
                    goalVertice = edge.GetOtherVertex(goalVertice);
                }

                result.Add(startWord);
                result.Reverse();
            }

            return result;
        }
    }
}
