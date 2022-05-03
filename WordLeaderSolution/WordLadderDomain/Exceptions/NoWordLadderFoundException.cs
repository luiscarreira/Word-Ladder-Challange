using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
