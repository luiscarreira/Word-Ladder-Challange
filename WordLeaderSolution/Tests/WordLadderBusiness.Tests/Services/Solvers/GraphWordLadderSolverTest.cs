using FluentAssertions;
using System.Collections.Generic;
using WordLadderBusiness.Services.Solvers;
using WordLadderDomain.Models;
using Xunit;

namespace WordLadderBusiness.Tests.Services.Solvers
{
    public class GraphWordLadderSolverTest
    {
        [Fact]
        public void SolveWordLadder_WhenCalledWithValidParameters_ShallReturnTheShortestPathToEndWord()
        {
            //Arrange
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
            Word startWord = new("start");
            Word endWord = new("tarts");
            WordLadderDictionary dictionary = new(dictionaryEntries);

            var solver = new GraphWordLadderSolver();

            //Act
            var result = solver.SolveWordLadder(startWord, endWord, dictionary);

            //Assert
            result.Should().NotBeNull();
            result.GetWordsInPath().Should().HaveCount(7);
        }

        [Fact]
        public void SolveWordLadder_WhenCalledWithStartWordNotPresentInDictionary_ShallReturnEmptyPath()
        {
            //Arrange
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
            Word startWord = new("aaaaa");
            Word endWord = new("tarts");
            WordLadderDictionary dictionary = new(dictionaryEntries);

            var solver = new GraphWordLadderSolver();

            //Act
            var result = solver.SolveWordLadder(startWord, endWord, dictionary);

            //Assert
            result.Should().NotBeNull();
            result.GetWordsInPath().Should().BeEmpty();
        }

        [Fact]
        public void SolveWordLadder_WhenCalledWithEndWordNotPresentInDictionary_ShallReturnEmptyPath()
        {
            //Arrange
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
            Word startWord = new("start");
            Word endWord = new("bbbbb");
            WordLadderDictionary dictionary = new(dictionaryEntries);

            var solver = new GraphWordLadderSolver();

            //Act
            var result = solver.SolveWordLadder(startWord, endWord, dictionary);

            //Assert
            result.Should().NotBeNull();
            result.GetWordsInPath().Should().BeEmpty();
        }
    }
}