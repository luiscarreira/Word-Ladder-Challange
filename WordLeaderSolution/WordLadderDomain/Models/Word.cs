namespace WordLadderDomain.Models
{
    /// <summary>
    /// Word Domain Model
    /// </summary>
    public class Word
    {
        public string Value { get; private set; }

        private string OriginalValue { get; set; }

        public Word()
        {
            Value = OriginalValue = string.Empty;
        }

        public Word(string value)
        {
            OriginalValue = value;
            Value = value.ToUpper();
        }
    }
}
