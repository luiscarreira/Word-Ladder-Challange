using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using WordLadderDomain.Models;
using WordLadderFileSystemInfrastructure.Repositories;
using Xunit;

namespace WordLadderFileSystemInfrastructure.Tests.Repositories
{
    public class DictionaryRepositoryTest
    {
        [Fact]
        public async void LoadDictionaryAsync_WhenCalled_LoadsDictionaryFromFile()
        {
            //Arrange
            var dictionaryPath = @"c:\mydictionaryfile.txt";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { dictionaryPath, new MockFileData($"start{Environment.NewLine}end") }
            });
            
            var repository = new DictionaryRepository(dictionaryPath, fileSystem);

            //Act
            var result = await repository.LoadDictionaryAsync();

            //Assert
            result.Should().NotBeNull();
            result.ContainsWord(new Word("start")).Should().BeTrue();
            result.ContainsWord(new Word("end")).Should().BeTrue();
        }
    }
}
