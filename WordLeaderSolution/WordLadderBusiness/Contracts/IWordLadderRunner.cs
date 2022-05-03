using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderBusiness.Contracts
{
    public interface IWordLadderRunner
    {
        public Task RunAsync(string startWord, string endWord, CancellationToken token);
    }
}
