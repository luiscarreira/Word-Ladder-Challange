namespace WordLadderDomain.Models
{
    public class WordPath
    {
        public List<Word> Words { get; private set; }

        public WordPath()
        {
            Words = new List<Word>();
        }
    }
}
