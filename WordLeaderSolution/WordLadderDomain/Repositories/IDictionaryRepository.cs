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
        /// <returns></returns>
        public Task<WordLadderDictionary> LoadDictionaryAsync();
    }
}
