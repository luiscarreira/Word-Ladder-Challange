using WordLadderDomain.Models;

namespace WordLadderDomain.Comparers
{
    public class WordEqualityComparer : IEqualityComparer<Word>
    {
        public bool Equals(Word? x, Word? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Value.SequenceEqual(y.Value);
        }

        public int GetHashCode(Word obj)
        {
            return (obj.Value != null ? obj.Value.GetHashCode() : 0);
        }
    }
}
