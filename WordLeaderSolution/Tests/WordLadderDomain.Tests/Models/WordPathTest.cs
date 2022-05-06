using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using WordLadderDomain.Models;
using Xunit;

namespace WordLadderDomain.Tests.Models
{
    public class WordPathTest
    {
        [Fact]
        public void DefaultConstructor_WhenCalled_CreateWordPathWithEmptyListOfWords()
        {
            //Arrange

            //Act
            var wordPath = new WordPath();

            //Assert
            wordPath.Should().BeOfType<WordPath>();
            wordPath.GetWordsInPath().Should().NotBeNull();
            wordPath.GetWordsInPath().Should().BeEmpty();
        }

        [Fact]
        public void GetWordsInPath_WhenCalled_ReturnsTheListOfWordsInPath()
        {
            //Arrange
            var wordPath = new WordPath();
            var word1 = new Word("word1");
            var word2 = new Word("word2");

            wordPath.AppendWordToPath(word1);
            wordPath.AppendWordToPath(word2);

            //Act
            var result = wordPath.GetWordsInPath();

            //Assert
            result.Should().BeAssignableTo<IReadOnlyList<Word>>();
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Value.Should().Be(word1.Value);
            result[1].Value.Should().Be(word2.Value);
        }

        [Fact]
        public void AppendWordToPath_WhenCalled_AppendWordToTheEndOfTheCollection()
        {
            //Arrange
            var wordPath = new WordPath();
            var word1 = new Word("word1");
            var word2 = new Word("word2");

            wordPath.AppendWordToPath(word1);

            //Act
            wordPath.AppendWordToPath(word2);
            var result = wordPath.GetWordsInPath();

            //Assert
            result.Should().BeAssignableTo<IReadOnlyList<Word>>();
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Last().Should().Be(word2);
        }

        [Fact]
        public void AppendWordsToPath_WhenCalled_AppendWordsToTheEndOfTheCollection()
        {
            //Arrange
            var wordPath = new WordPath();
            var word1 = new Word("word1");
            var wordsCollection = new List<Word>
            {
                new Word("wordInCollection1"),
                new Word("wordInCollection2"),
                new Word("wordInCollection3")
            };

            wordPath.AppendWordToPath(word1);

            //Act
            wordPath.AppendWordsToPath(wordsCollection);
            var result = wordPath.GetWordsInPath();

            //Assert
            result.Should().BeAssignableTo<IReadOnlyList<Word>>();
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
            result.First().Should().Be(word1);
            result.Last().Should().Be(wordsCollection.Last());
        }
    }
}
