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

    public class WordPathV2
    {
        public string StartWord { get; private set; }

        public List<string> Words { get; private set; }

        public WordPathV2(string word)
        {
            Words = new List<string>();
            StartWord = word;
        }
    }
}
