using Istepaniuk.StringDistance.DamerauLevenshtein;
using NUnit.Framework;
using FluentAssertions;

namespace Istepaniuk.StringDistance.Tests
{
    [TestFixture]
    public class DamerauLevenstheinDistanceCalculatorTests
    {
        private DamerauLevenstheinDistanceCalculator calculator;

        [TestFixtureSetUp]
        public void SetUp()
        {
            calculator = new DamerauLevenstheinDistanceCalculator();
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

        [Test]
        public void IfBothStringsAreEmptyTheDistanceIsZero()
        {
            calculator.Distance(string.Empty, string.Empty).Should().Be(0);
        }

        [Test]
        public void IfAStringIsAreEmptyTheDistanceIsTheLengthOfTheOtherOne()
        {
            calculator.Distance(string.Empty, "1234").Should().Be(4);
            calculator.Distance("1234", string.Empty).Should().Be(4);
        }

        [Test]
        public void IfBothStringsAreNullTheDistanceIsZero()
        {
            calculator.Distance(null, null).Should().Be(0);
        }

        [Test]
        public void IfAStringIsNullTheDistanceIsTheLengthOfTheOtherOne()
        {
            calculator.Distance(null, "1234").Should().Be(4);
            calculator.Distance("1234", null).Should().Be(4);
        }

        [Test]
        public void DistanceIsOneIfOnePermutationIsNeeded()
        {
            calculator.Distance("abcd", "abdc").Should().Be(1);
        }

        [Test]
        public void DistanceIsTwoIfTwoPermutationsAreNeeded()
        {
            calculator.Distance("abcd", "adbc").Should().Be(2);
        }
    }
}

