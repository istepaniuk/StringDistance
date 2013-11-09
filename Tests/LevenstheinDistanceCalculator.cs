using System;
using Istepaniuk.StringDistance;
using NUnit.Framework;
using FluentAssertions;

namespace Istepaniuk.StringDistance
{
    [TestFixture]
    public class LevenstheinDistanceCalculatorTests
    {
        [Test]
        public void TwoEqualStringsHaveDistanceZero ()
        {
            var calculator = new LevenstheinDistanceCalculator();

            calculator.Distance("hello", "hello").Should().Be(0);
        }

        [Test]
        public void TwoStringsThatDifferInOneLetterHaveDistanceOfOne ()
        {
            var calculator = new LevenstheinDistanceCalculator();

            calculator.Distance("hello", "mello").Should().Be(1);
        }
    }
}

