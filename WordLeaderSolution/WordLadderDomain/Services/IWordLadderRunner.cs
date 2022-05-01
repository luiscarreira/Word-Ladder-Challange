using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderDomain.Services
{
    public interface IWordLadderRunner
    {
        public Task RunAsync(string startWord, string endWord, CancellationToken token);
    }
}
