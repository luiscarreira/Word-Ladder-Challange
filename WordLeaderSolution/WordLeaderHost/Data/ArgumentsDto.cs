using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderHost.Data
{
    internal class ArgumentsDto
    {
        internal string StartWord { get; set; }

        internal string EndWord { get; set; }

        internal string DictionaryPath { get; set; }

        internal string ResultPath { get; set; }

        internal int MaxWordLenght { get; set; }

        internal ArgumentsDto(string startWord, string endWord, string dictionaryPath, string resultPath, int maxWordLenght)
        {
            StartWord = startWord;
            EndWord = endWord;
            DictionaryPath = dictionaryPath;
            ResultPath = resultPath;
            MaxWordLenght = maxWordLenght;
        }
    }
}
