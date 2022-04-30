namespace WordLadderDomain.Models
{
    /// <summary>
    /// Dictionary Domain Model
    /// </summary>
    public class WordLadderDictionary
    {
        public IReadOnlyList<string> DictionaryEntries { get; private set; }

        public WordLadderDictionary()
        {
            DictionaryEntries = new List<string>();
        }

        public WordLadderDictionary(IReadOnlyList<string> dicitonaryEntries)
        {
            DictionaryEntries = dicitonaryEntries;
        }
    }
}
