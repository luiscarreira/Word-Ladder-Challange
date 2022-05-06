using System.IO.Abstractions;
using WordLadderDomain.Models;
using WordLadderDomain.Repositories;

namespace WordLadderFileSystemInfrastructure.Repositories
{
    public class PathRepository : IPathRepository
    {
        private readonly IFileSystem fileSystem;
        private readonly string pathFilePath;

        /// <summary>
        /// PathRepository constructor
        /// </summary>
        /// <param name="pathFilePath"></param>
        public PathRepository(string pathFilePath)
        {
            this.pathFilePath = pathFilePath;
            fileSystem = new FileSystem();
        }

        /// <summary>
        /// PathRepository constructor
        /// </summary>
        /// <param name="pathFilePath"></param>
        public PathRepository(string pathFilePath, IFileSystem fileSystem)
        {
            this.pathFilePath = pathFilePath;
            this.fileSystem = fileSystem;
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

            await fileSystem.File.WriteAllLinesAsync(pathFilePath + "\\result.txt", path.GetWordsInPath().Select(x => x.Value));
        }
    }
}
