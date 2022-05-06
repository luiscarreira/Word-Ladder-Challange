namespace WordLadderDomain.Models
{
    /// <summary>
    /// Word Domain Model
    /// </summary>
    public class Word
    {
        public string Value { get; private set; }

        public Word()
        {
            Value = string.Empty;
        }

        public Word(string value)
        {
            Value = value.ToUpper();
        }
    }
}
