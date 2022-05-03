namespace WordLadderDomain.Models
{
    /// <summary>
    /// Word Domain Model
    /// </summary>
    public class Word
    {
        public string Value { get; private set; }
        //public int MatchingLettersCount { get; private set; }

        public Word()
        {
            Value = string.Empty;
            //MatchingLettersCount = 0;
        }

        public Word(string value/*, int matchingLettersCount*/)
        {
            Value = value;
            //MatchingLettersCount = matchingLettersCount;
        }
    }
}
