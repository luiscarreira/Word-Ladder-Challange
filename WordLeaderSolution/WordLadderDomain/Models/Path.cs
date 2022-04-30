namespace WordLadderDomain.Models
{
    public class Path
    {
        public IReadOnlyList<Word> Words { get; private set; }

        public Path()
        {
            Words = new List<Word>();
        }
    }
}
