using WordLadderDomain.Models;

namespace WordLadderDomain.Repositories
{
    /// <summary>
    /// Dictionary Repository
    /// </summary>
    public interface IDictionaryRepository
    {
        /// <summary>
        /// Load Dictionary contract
        /// </summary>
        /// <param name="maxWordLenghtAllowed">The max word lenght allowed (it defaults to Int32 max length)</param>
        /// <returns></returns>
        public Task<WordLadderDictionary> LoadDictionaryAsync(int maxWordLenghtAllowed = Int32.MaxValue);
    }
}
