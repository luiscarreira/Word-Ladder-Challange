using FluentAssertions;
using WordLadderDomain.Models;
using Xunit;

namespace WordLadderDomain.Tests.Models
{
    public class WordTest
    {
        [Fact]
        public void DefaultConstructor_WhenCalled_CreateWordWithEmptyValues()
        {
            //Arrange

            //Act
            var word = new Word();

            //Assert
            word.Should().BeOfType<Word>();
            word.Value.Should().BeEmpty();
        }

        [Fact]
        public void CustomConstructor_WhenCalled_CreateWordWithGivenValuesInUpperCase()
        {
            //Arrange
            var text = "Test";

            //Act
            var word = new Word(text);

            //Assert
            word.Should().BeOfType<Word>();
            word.Value.Should().Be(text.ToUpper());
        }
    }
}
