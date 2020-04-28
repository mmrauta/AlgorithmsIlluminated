using AlgorithmsIlluminated;
using System;
using Xunit;

namespace AlgorithmsTests
{
    public class KaratsubaTest
    {
        [Fact]
        public void NonNumber_Characters_Throws_Exception()
        {
            Action invalidExecution = () => KaratsubaMultiplication.Calculate("1s", "1");
            Assert.Throws<ArgumentException>(invalidExecution);
        }

        [Fact]
        public void No_Characters_Throws_Exception()
        {
            Action invalidExecution = () => KaratsubaMultiplication.Calculate("", "");
            Assert.Throws<ArgumentException>(invalidExecution);
        }

        [Theory]
        [InlineData("1","1", 1)]
        [InlineData("0", "0", 0)]
        [InlineData("0", "1", 0)]
        [InlineData("2", "5", 10)]
        public void Multiply_Simple_Values(string firstNumber, string secondNumber, int expectedResult)
        {
            var result = KaratsubaMultiplication.Calculate(firstNumber, secondNumber);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("10", "10", 100)]
        [InlineData("100", "0", 0)]
        [InlineData("25", "25", 625)]
        [InlineData("123", "123", 15129)]
        [InlineData("1234", "1000", 1234000)]
        public void Multiply_Complex_Values(string firstNumber, string secondNumber, int expectedResult)
        {
            var result = KaratsubaMultiplication.Calculate(firstNumber, secondNumber);
            Assert.Equal(expectedResult, result);
        }
    }
}
