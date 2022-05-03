namespace WordLadderDomain.Models
{
    public class WordBucket
    {
        public string Identifier { get; private set; }

        public IList<Word> Words { get; private set; }

        public WordBucket(string identifier)
        {
            Identifier = identifier;
            Words = new List<Word>();
        }
    }
}
