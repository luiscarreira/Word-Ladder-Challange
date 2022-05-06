namespace WordLadderDomain.Models
{
    public class WordPath
    {
        private List<Word> Words { get; set; }

        public WordPath()
        {
            Words = new List<Word>();
        }

        /// <summary>
        /// Get the Collection of Word in a Path
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Word> GetWordsInPath()
        {
            return Words.AsReadOnly();
        }

        /// <summary>
        /// Append a given Word to the Path
        /// </summary>
        /// <param name="word"></param>
        public void AppendWordToPath(Word word)
        {
            Words.Add(word);
        }

        /// <summary>
        /// Append a given collection of Words to the Path
        /// </summary>
        /// <param name="words"></param>
        public void AppendWordsToPath(IReadOnlyList<Word> words)
        {
            Words.AddRange(words);
        }
    }
}
