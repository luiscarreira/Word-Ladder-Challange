using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordLadderDomain.Models;

namespace WordLadderDomain.Services
{
    public class WordBucketService
    {
        private Regex OnlyLettersRegEx = new("^[a-zA-Z]*$");

        private List<WordBucket> wordBuckets;

        public WordBucketService()
        {
            wordBuckets = new();
        }

        public bool GenerateWordBucketsForWordsWithOnlyLetters(WordLadderDictionary dictionary, int wordLength)
        {
            try
            {
                foreach (string word in dictionary.DictionaryEntries)
                {
                    if (word.Length == wordLength && OnlyLettersRegEx.IsMatch(word))
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            StringBuilder sb = new(word);
                            sb[i] = '*';
                            string bucketIdentifier = sb.ToString();

                            if (wordBuckets.Any(x => x.Identifier == bucketIdentifier))
                            {
                                wordBuckets.First(x => x.Identifier == bucketIdentifier).Words.Add(new Word(word));
                            }
                            else
                            {
                                var newBucket = new WordBucket(bucketIdentifier);
                                newBucket.Words.Add(new Word(word));
                                wordBuckets.Add(newBucket);
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<WordBucket> GetMatchingBucketsForWord(Word word)
        {
            var result = new List<WordBucket>();

            for (int i = 0; i < word.Value.Length; i++)
            {
                StringBuilder sb = new(word.Value);
                sb[i] = '*';
                string bucketIdentifier = sb.ToString();

                if (wordBuckets.Any(x => x.Identifier == bucketIdentifier))
                {
                    result.Add(wordBuckets.First(x => x.Identifier == bucketIdentifier));
                }
            }

            return result;
        }
    }
}
