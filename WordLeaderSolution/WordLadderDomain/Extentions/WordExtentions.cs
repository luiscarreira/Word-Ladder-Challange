using WordLadderDomain.Models;

namespace WordLadderDomain.Extentions
{
    public static class WordExtentions
    {
        /// <summary>
        /// Counts the numbers of matching characteres between two Words
        /// </summary>
        /// <param name="wordA"></param>
        /// <param name="wordB"></param>
        /// <returns>The Number of Matching Characters. If The words have different lenghts it returns -1.</returns>
        public static int NumberOfMacthingChars(this Word wordA, Word wordB)
        {
            int result = -1;
            if (wordA.Value.Length == wordB.Value.Length)
            {
                result = wordA.Value.Where((x, i) => x.Equals(wordB.Value[i])).Count();
            }

            return result;
        }
    }
}
