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

        public override bool Equals(object? otherWord)
        {
            if (ReferenceEquals(this, otherWord)) return true;
            if (otherWord is null) return false;
            if (this.GetType() != otherWord.GetType()) return false;
            return this.Value.SequenceEqual(((Word)otherWord).Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Value);
        }
    }
}
