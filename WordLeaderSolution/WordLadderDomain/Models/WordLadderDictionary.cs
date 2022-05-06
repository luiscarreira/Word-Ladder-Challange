using WordLadderDomain.Comparers;
using WordLadderDomain.Extentions;

namespace WordLadderDomain.Models
{
    /// <summary>
    /// Dictionary Domain Model
    /// </summary>
    public class WordLadderDictionary
    {
        private IReadOnlyList<Word> DictionaryEntries { get; set; }

        /// <summary>
        /// Construct a Word Ladder Dictionary based on a set of words and the maximum word lenght allowed
        /// </summary>
        /// <param name="dicitonaryEntries">The collection of words</param>
        /// <param name="maxWordLenghtAllowed">The max word lenght allowed (it defaults to Int32 max length)</param>
        public WordLadderDictionary(IReadOnlyList<string> dicitonaryEntries, int maxWordLenghtAllowed = Int32.MaxValue)
        {
            if(dicitonaryEntries == null)
            {
                throw new ArgumentNullException(nameof(dicitonaryEntries));
            }

            IEnumerable<string> filtredDictionartEntries;
            if (maxWordLenghtAllowed == Int32.MaxValue)
            {
                filtredDictionartEntries = dicitonaryEntries.Where(x => x.Length <= maxWordLenghtAllowed);
            }
            else
            {
                filtredDictionartEntries = dicitonaryEntries.Where(x => x.Length == maxWordLenghtAllowed);
            }

            DictionaryEntries = filtredDictionartEntries.Select(x => new Word(x.ToUpper())).ToList();
        }

        /// <summary>
        /// Verifies if a given word exists on the Dictionary
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool ContainsWord(Word word)
        {
            return DictionaryEntries.Any(x => x.Equals(word));
        }

        /// <summary>
        /// Obtains a list of Words from the Dictionary that differs a given number of characters from a given word
        /// </summary>
        /// <param name="word">The word that will serve as base for the search</param>
        /// <param name="numberOfDifferentLetters">The number of chars that words on the Dictionart can differ to the given word</param>
        /// <param name="excludedWords">An optional collection of Words to be ignored in the search</param>
        /// <returns>Collection of words from the Dictionary that differs the given number of characters from the given word</returns>
        public IReadOnlyList<Word> GetWordsThatDifferGivenNumberOfLetters(
            Word word,
            int numberOfDifferentLetters,
            IEnumerable<Word>? excludedWords = default)
        {
            var result = new List<Word>();

            var collectionToAnalyse = excludedWords == null ? DictionaryEntries : DictionaryEntries.Except(excludedWords, new WordEqualityComparer());

            foreach (var dictionaryWord in collectionToAnalyse)
            {
                var numberOfChanges = dictionaryWord.Value.Length - word.NumberOfMacthingChars(dictionaryWord);
                if (numberOfChanges == numberOfDifferentLetters)
                {
                    result.Add(dictionaryWord);
                }
            }
            return result;
        }
    }
}
