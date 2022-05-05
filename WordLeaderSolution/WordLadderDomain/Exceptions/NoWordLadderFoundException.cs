namespace WordLadderDomain.Exceptions
{
    public class NoWordLadderFoundException : Exception
    {
        public NoWordLadderFoundException() 
            : base()
        {

        }

        public NoWordLadderFoundException(string message) :
            base(message)
        {

        }
    }
}
