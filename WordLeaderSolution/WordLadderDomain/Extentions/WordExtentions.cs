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
        /// <returns></returns>
        public static int NumberOfMacthingChars(this Word wordA, Word wordB)
        {
            int result = 0;
            if (wordA.Value.Length == wordB.Value.Length)
            {
                result = wordA.Value.Where((x, i) => x.Equals(wordB.Value[i])).Count();
            }

            return result;
        }

        /// <summary>
        /// Verifies is two Words are equals
        /// </summary>
        /// <param name="wordA"></param>
        /// <param name="wordB"></param>
        /// <returns></returns>
        public static bool IsEqual(this Word wordA, Word wordB)
        {
            return wordA.Value.SequenceEqual(wordB.Value);
        }
    }
}
