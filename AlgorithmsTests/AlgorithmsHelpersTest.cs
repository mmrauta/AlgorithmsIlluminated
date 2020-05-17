using AlgorithmsIlluminated;
using System;
using Xunit;

namespace AlgorithmsTests
{
    public class AlgorithmsHelpersTest
    {
        [Theory]
        [InlineData("1", "1", "1", "1")]
        [InlineData("0", "02", "00", "02")]
        [InlineData("1023", "11", "1023", "0011")]
        public void Get_The_Same_Length_Numbers(string firstNumber, string secondNumber, string firstExpectedResult,
            string secondExpectedResult)
        {
            var (numberOne, numberTwo) = AlgorithmsHelper.GetTheSameLengthNumbers(firstNumber, secondNumber);
            Assert.Equal(firstExpectedResult, numberOne);
            Assert.Equal(secondExpectedResult, numberTwo);
        }

        [Theory]
        [InlineData("1", "01")]
        [InlineData("003", "0003")]
        [InlineData("998", "0998")]
        [InlineData("56", "56")]
        [InlineData("", "")]
        public void Get_Even_Digits_Numbers(string number, string expectedResult)
        {
            var result = AlgorithmsHelper.GetEvenDigitsNumber(number);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void No_Characters_Throws_Exception()
        {
            Action invalidExecution = () => AlgorithmsHelper.EnsureNumber("");
            Assert.Throws<ArgumentException>(invalidExecution);
        }

        [Fact]
        public void NonNumber_Characters_Throws_Exception()
        {
            Action invalidExecution = () => AlgorithmsHelper.EnsureNumber("1s");
            Assert.Throws<ArgumentException>(invalidExecution);
        }
    }
}