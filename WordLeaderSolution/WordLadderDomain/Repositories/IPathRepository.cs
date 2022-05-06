using WordLadderDomain.Models;

namespace WordLadderDomain.Repositories
{
    public interface IPathRepository
    {
        /// <summary>
        /// Persist a given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task PersistPathAsync(WordPath path);
    }
}
