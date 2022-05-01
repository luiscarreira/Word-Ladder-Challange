using WordLadderDomain.Models;
using WordLadderDomain.Repositories;

namespace WordLadderFileSystemInfrastructure.Repositories
{
    public class PathRepository : IPathRepository
    {
        private readonly string pathFilePath;

        /// <summary>
        /// PathRepository constructor
        /// </summary>
        /// <param name="pathFilePath"></param>
        public PathRepository(string pathFilePath)
        {
            this.pathFilePath = pathFilePath;
        }

        public async Task PersistPathAsync(WordPath path)
        {
            if(string.IsNullOrEmpty(pathFilePath))
            {
                throw new ArgumentNullException(nameof(pathFilePath));
            }

            if(path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            await File.WriteAllLinesAsync(pathFilePath + "\\result.txt", path.Words.Select(x => x.Value));
        }
    }
}
