using System;
using Istepaniuk.StringDistance;
using NUnit.Framework;
using FluentAssertions;

namespace Istepaniuk.StringDistance
{
    [TestFixture]
    public class LevenstheinDistanceCalculatorTests
    {
        private LevenstheinDistanceCalculator calculator;

        [TestFixtureSetUp]
        public void SetUp()
        {
            calculator = new LevenstheinDistanceCalculator();
        }

        [Test]
        public void TwoEqualStringsHaveDistanceZero()
        {
            calculator.Distance("hello", "hello").Should().Be(0);
        }

        [Test]
        public void TwoStringsThatDifferInOneLetterHaveDistanceOfOne()
        {
            calculator.Distance("hello", "mello").Should().Be(1);
        }

        [Test]
        public void TwoStringsThatDifferInOneLetterCaseHaveDistanceOfOne()
        {
            calculator.Distance("hello", "Hello").Should().Be(1);
        }

        [Test]
        public void TwoStringsThatDifferInTeoLettersHaveDistanceOfTwo()
        {
            calculator.Distance("hello", "tallo").Should().Be(2);
        }

        [Test]
        public void TwoStringsThatDifferInOneLettersHaveDistanceOfOneIfOneDeletionIsNeeded()
        {
            calculator.Distance("hello", "hell").Should().Be(1);
        }

        [Test]
        public void TwoStringsThatDifferInOneLettersHaveDistanceOfOneIfOneInsertionIsNeeded()
        {
            calculator.Distance("hell", "hello").Should().Be(1);
        }

        [Test]
        public void TwoStringsThatDifferInTwoLettersHaveDistanceOfTwoIfTwoInsertionsAreNeeded()
        {
            calculator.Distance("hell", "hellow").Should().Be(2);
        }
    }
}

