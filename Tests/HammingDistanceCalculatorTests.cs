using System;
using NUnit.Framework;
using FluentAssertions;

namespace Istepaniuk.StringDistance.Tests
{
    [TestFixture]
    public class HammingDistanceCalculatorTests
    {
        private HammingDistanceCalculator calculator;

        [TestFixtureSetUp]
        public void SetUp()
        {
            calculator = new HammingDistanceCalculator();
        }

        [Test]
        public void RaisesAnExceptionIfStringsDifferInLength()
        {
            Action calculate = () => calculator.Calculate("short string", "another, longer string"); 

            calculate.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void EqualStringsHaveADistanceOfZero()
        {
            calculator.Calculate("hello", "hello").Should().Be(0);
        }

        [Test]
        public void StringsWithOneDifferentLetterHaveADistanceOfOne()
        {
            calculator.Calculate("hello", "mello").Should().Be(1);
        }

        [Test]
        public void TotallyDifferentStringsHaveADistanceEqualToTheirLength()
        {
            calculator.Calculate("hello", "adios").Should().Be(5);
        }
    }
}

