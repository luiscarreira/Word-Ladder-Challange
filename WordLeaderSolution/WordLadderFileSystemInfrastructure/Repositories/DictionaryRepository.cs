using System.Text;
using WordLadderDomain.Models;
using WordLadderDomain.Repositories;

namespace WordLadderFileSystemInfrastructure.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly string dictionaryFilePath;

        /// <summary>
        /// DictionaryRepository constructor
        /// </summary>
        /// <param name="dictionaryFilePath"></param>
        public DictionaryRepository(string dictionaryFilePath)
        {
            this.dictionaryFilePath = dictionaryFilePath;
        }

        /// <inheritdoc/>
        public async Task<WordLadderDictionary> LoadDictionaryAsync(int maxWordLenghtAllowed = Int32.MaxValue)
        {
            var fileLines = await File.ReadAllLinesAsync(dictionaryFilePath, Encoding.UTF8);
            return new WordLadderDictionary(fileLines, maxWordLenghtAllowed);
        }
    }
}
