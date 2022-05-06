using WordLadderDomain.Models;

namespace WordLadderBusiness.Contracts
{
    public interface IWordLadderSolver
    {
        /// <summary>
        /// Solve Word Ladder for the given parameters
        /// </summary>
        /// <param name="startWord">The start word</param>
        /// <param name="endWord">The end word</param>
        /// <param name="dictionary">The dictionary to use</param>
        /// <returns>The shortest Word Path between start and end words in the given dictionary</returns>
        /// <exception cref=""></exception>
        public WordPath SolveWordLadder(Word startWord, Word endWord, WordLadderDictionary dictionary);
    }
}
