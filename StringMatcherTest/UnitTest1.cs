using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringMatcher.Interfaces;
using StringMatcher.Models;
using StringMatcher.Providers;
using System.Collections.Generic;
using static StringMatcher.Helpers.EnumHelper;

namespace StringMatcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatchSingleString()
        {
            //Arrange
            int expected = 10;
            Compare input = new Compare();
            input.InputString = "This is a unit test";
            input.SubString = "unit";
            input.CaseSearch = CaseSearch.MatchCase;

            //Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            Assert.AreEqual(expected, actual.MatchedWords[0].startIndex);
        }

        [TestMethod]
        public void TestMatchMultipeString()
        {
            //Arrange
            List<MatchedWord> expectedList = new List<MatchedWord>()
            {
                new MatchedWord() { startIndex = 10, finishIndex = 14 },
                new MatchedWord() { startIndex = 23, finishIndex = 27}
            };

            Compare input = new Compare();
            input.InputString = "This is a test in Unit testing project";
            input.SubString = "test";
            input.CaseSearch = CaseSearch.MatchCase;

            //Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                var expectedValue = expectedList[i];
                Assert.AreEqual(expectedValue.finishIndex, actual.MatchedWords[i].finishIndex);
                Assert.AreEqual(expectedValue.startIndex, actual.MatchedWords[i].startIndex);
            }

        }

        [TestMethod]
        public void TestMatchMultipeStringIgnoreCase()
        {
            // Arrange
            List<MatchedWord> expectedList = new List<MatchedWord>()
            {
                new MatchedWord() { startIndex = 10, finishIndex = 14 },
                new MatchedWord() { startIndex = 23, finishIndex = 27}
            };


            Compare input = new Compare();
            input.InputString = "This is a Test in Unit testing project";
            input.SubString = "test";
            input.CaseSearch = CaseSearch.IgnoreCase;

            // Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                var expectedValue = expectedList[i];
                Assert.AreEqual(expectedValue.finishIndex, actual.MatchedWords[i].finishIndex);
                Assert.AreEqual(expectedValue.startIndex, actual.MatchedWords[i].startIndex);
            }
        }

        [TestMethod]
        public void TestMatchMultipeStringIntheSameWord()
        {
            //Arrange
            List<MatchedWord> expectedList = new List<MatchedWord>()
            {
                new MatchedWord() { startIndex = 0, finishIndex = 2 },
                new MatchedWord() { startIndex = 6, finishIndex = 8}
            };

            Compare input = new Compare();
            input.InputString = "AdssssAd";
            input.SubString = "Ad";
            input.CaseSearch = CaseSearch.MatchCase;

            //Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                var expectedValue = expectedList[i];
                Assert.AreEqual(expectedValue.finishIndex, actual.MatchedWords[i].finishIndex);
                Assert.AreEqual(expectedValue.startIndex, actual.MatchedWords[i].startIndex);
            }

        }

        [TestMethod]
        public void TestMatchMultipeStringIntheSameWordIgnoreCase()
        {
            // Arrange
            List<MatchedWord> expectedList = new List<MatchedWord>()
            {
                new MatchedWord() { startIndex = 0, finishIndex = 2 },
                new MatchedWord() { startIndex = 6, finishIndex = 8}
            };


            Compare input = new Compare();
            input.InputString = "Adssssad";
            input.SubString = "Ad";
            input.CaseSearch = CaseSearch.IgnoreCase;

            // Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                var expectedValue = expectedList[i];
                Assert.AreEqual(expectedValue.finishIndex, actual.MatchedWords[i].finishIndex);
                Assert.AreEqual(expectedValue.startIndex, actual.MatchedWords[i].startIndex);
            }
        }

        [TestMethod]
        public void ShouldIgnoreWhiteSpace()
        {
            //Arrange
            
            int expected = 10;
            Compare input = new Compare();
            input.InputString = "\n\t\rThis is a unit test";
            input.SubString = "unit";
            input.CaseSearch = CaseSearch.MatchCase;

            //Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            Assert.AreEqual(expected, actual.MatchedWords[0].startIndex);
        }


        [TestMethod]
        public void ShouldIgnoreWhiteSpaceAtEnd()
        {
            //Arrange

            int expected = 10;
            Compare input = new Compare();
            input.InputString = "This is a unit test\n\t\r";
            input.SubString = "unit";
            input.CaseSearch = CaseSearch.MatchCase;

            //Act
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);
            var actual = provider.findWords();

            //Assert
            Assert.AreEqual(expected, actual.MatchedWords[0].startIndex);
        }
    }
}
