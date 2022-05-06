using FluentAssertions;
using System;
using System.IO.Abstractions.TestingHelpers;
using WordLadderDomain.Models;
using WordLadderFileSystemInfrastructure.Repositories;
using Xunit;

namespace WordLadderFileSystemInfrastructure.Tests.Repositories
{
    public class PathRepositoryTest
    {
        [Fact]
        public async void LoadDictionaryAsync_WhenCalledWithValidParamters_DontThrowAnyException()
        {
            //Arrange
            var resultPath = @"c:\";
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(resultPath);

            var repository = new PathRepository(resultPath, fileSystem);

            //Act + Assert
            await repository.PersistPathAsync(new WordPath());           
        }

        [Fact]
        public async void LoadDictionaryAsync_WhenCalledWithEmptyPath_ThrowArgumentException()
        {
            //Arrange
            var resultPath = string.Empty;

            var repository = new PathRepository(resultPath);

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.PersistPathAsync(new WordPath()));

            //Assert
            exception.ParamName.Should().Be("pathFilePath");
        }

        [Fact]
        public async void LoadDictionaryAsync_WhenCalledWithNullWordPath_ThrowArgumentException()
        {
            //Arrange
            var resultPath = @"c:\";
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(resultPath);

            var repository = new PathRepository(resultPath);

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.PersistPathAsync(null));

            //Assert
            exception.ParamName.Should().Be("path");
        }
    }
}
