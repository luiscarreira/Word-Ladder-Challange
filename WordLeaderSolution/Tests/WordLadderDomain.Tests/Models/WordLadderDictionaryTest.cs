using FluentAssertions;
using System;
using System.Collections.Generic;
using WordLadderDomain.Models;
using Xunit;

namespace WordLadderDomain.Tests.Models
{
    public class WordLadderDictionaryTest
    {
        [Fact]
        public void CustomConstructor_WhenCalledWithNullEntries_ShallThrowArgumentNullExceptionn()
        {
            //Arrange
            List<string> entries = null;

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WordLadderDictionary(entries));

            //Assert
            ex.Should().BeOfType<ArgumentNullException>();
            ex.ParamName.Should().Be("dicitonaryEntries");
        }
    }
}
