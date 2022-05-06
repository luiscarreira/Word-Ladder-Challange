using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using WordLadderDomain.Extentions;
using WordLadderDomain.Models;
using Xunit;

namespace WordLadderDomain.Tests.Extentions
{
    public class WordExtentionsTest
    {
        [Fact]
        public void NumberOfMacthingChars_WhenTwoWordsAreEqual_ShallReturnAValueEqualsToTheTwoWordsLenght()
        {
            //Arrange
            var word1 = new Word("test");
            var word2 = new Word("test");

            //Act
            var result = word1.NumberOfMacthingChars(word2);

            //Assert
            result.Should().BeOfType(typeof(int));
            result.Should().Be(word1.Value.Length);
            result.Should().Be(word2.Value.Length);
        }

        [Fact]
        public void NumberOfMacthingChars_CallingInEachDirection_ShallReturnTheSameValue()
        {
            //Arrange
            var word1 = new Word("test");
            var word2 = new Word("same");

            //Act
            var result1 = word1.NumberOfMacthingChars(word2);
            var result2 = word2.NumberOfMacthingChars(word1);

            //Assert
            result1.Should().Be(result2);
        }

        [Fact]
        public void NumberOfMacthingChars_CallingWithWordsThatDiffersOneCharAndHaveLengthFour_ShallReturnThree()
        {
            //Arrange
            var word1 = new Word("test");
            var word2 = new Word("pest");

            //Act
            var result = word1.NumberOfMacthingChars(word2);

            //Assert
            result.Should().Be(3);
        }

        [Fact]
        public void NumberOfMacthingChars_CallingWithWordsOfDifferentLenghts_ShallReturnMinusOne()
        { 
            //Arrange
            var word1 = new Word("test");
            var word2 = new Word("testtest");

            //Act
            var result = word1.NumberOfMacthingChars(word2);

            //Assert
            result.Should().Be(-1);
        }               
    }
}
