namespace WordLadderDomain.Models
{
    public class WordPath
    {
        public IList<Word> Words { get; private set; }

        public WordPath()
        {
            Words = new List<Word>();
        }
    }
}
