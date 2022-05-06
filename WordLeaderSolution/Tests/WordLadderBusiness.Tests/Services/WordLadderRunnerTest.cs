using Moq;
using System;
using System.Collections.Generic;
using WordLadderBusiness.Contracts;
using WordLadderBusiness.Services;
using WordLadderDomain.Models;
using WordLadderDomain.Repositories;
using Xunit;


namespace WordLadderBusiness.Tests.Services
{
    public class WordLadderRunnerTest
    {
        [Fact]
        public async void RunAsync_WhenCalledWithValidParameters_ShallCallPersistPathOnce()
        {
            //Arrange
            var dictionartRepositoryMock = new Mock<IDictionaryRepository>();
            var pathRepositoryMock = new Mock<IPathRepository>();
            var solverMock = new Mock<IWordLadderSolver>();

            List<string> dictionaryEntries = new()
            {
                "bears",
                "parts",
                "teats",
                "tarts",
                "boats",
                "start",
                "ports",
                "stars",
                "beats",
                "coats",
                "seats",
                "posts",
                "sears",
                "costs",
                "terts"
            };

            var dictionary = new WordLadderDictionary(dictionaryEntries);
            var startWord = "start";
            var endWord = "tarts";
            var path = new WordPath();
            path.AppendWordsToPath(new List<Word>
            {
                new Word(startWord),
                new Word(endWord)
            });

            dictionartRepositoryMock.Setup(x => x.LoadDictionaryAsync(Int32.MaxValue)).ReturnsAsync(dictionary);
            solverMock.Setup(x => x.SolveWordLadder(It.Is<Word>(y => y.Value == startWord.ToUpper()), It.Is<Word>(y => y.Value == endWord.ToUpper()), dictionary)).Returns(path);
            pathRepositoryMock.Setup(x => x.PersistPathAsync(path));

            var runner = new WordLadderRunner(dictionartRepositoryMock.Object, pathRepositoryMock.Object);

            //Act
            await runner.RunAsync(solverMock.Object, startWord, endWord, System.Threading.CancellationToken.None);

            //Assert
            pathRepositoryMock.Verify(x => x.PersistPathAsync(path), Times.Once);
        }

        [Fact]
        public async void RunAsync_WhenCalledWithParametersThatReturnsNoPath_ShallNotCallPersistPath()
        {
            //Arrange
            var dictionartRepositoryMock = new Mock<IDictionaryRepository>();
            var pathRepositoryMock = new Mock<IPathRepository>();
            var solverMock = new Mock<IWordLadderSolver>();

            List<string> dictionaryEntries = new()
            {
                "bears",
                "parts",
                "teats",
                "tarts",
                "boats",
                "start",
                "ports",
                "stars",
                "beats",
                "coats",
                "seats",
                "posts",
                "sears",
                "costs",
                "terts"
            };

            var dictionary = new WordLadderDictionary(dictionaryEntries);
            var startWord = "aaaaa";
            var endWord = "tarts";
            var path = new WordPath();

            dictionartRepositoryMock.Setup(x => x.LoadDictionaryAsync(Int32.MaxValue)).ReturnsAsync(dictionary);
            solverMock.Setup(x => x.SolveWordLadder(It.Is<Word>(y => y.Value == startWord.ToUpper()), It.Is<Word>(y => y.Value == endWord.ToUpper()), dictionary)).Returns(path);
            pathRepositoryMock.Setup(x => x.PersistPathAsync(path));

            var runner = new WordLadderRunner(dictionartRepositoryMock.Object, pathRepositoryMock.Object);

            //Act
            await runner.RunAsync(solverMock.Object, startWord, endWord, System.Threading.CancellationToken.None);

            //Assert
            pathRepositoryMock.Verify(x => x.PersistPathAsync(path), Times.Never);
        }
    }
}
