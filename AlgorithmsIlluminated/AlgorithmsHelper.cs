using System;
using System.Linq;

namespace AlgorithmsIlluminated
{
    public static class AlgorithmsHelper
    {
        /// <summary>
        /// Gets two numbers with the same length by prepending zeroes to the shorter one.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>Two string representing numbers of the same lengths.</returns>
        public static (string numberOne, string numberTwo) GetTheSameLengthNumbers(string firstNumber, string secondNumber)
        {
            if (firstNumber.Length == secondNumber.Length)
            {
                return (firstNumber, secondNumber);
            }

            return firstNumber.Length > secondNumber.Length
                ? (firstNumber, secondNumber.PrependZeros(firstNumber.Length))
                : (firstNumber.PrependZeros(secondNumber.Length), secondNumber);
        }

        /// <summary>
        /// Get the number with even amount of digits by prepending '0' if the number has odd amount of digits.
        /// </summary>
        /// <param name="number">Number to transform</param>
        /// <returns>String with even amount of digits.</returns>
        public static string GetEvenDigitsNumber(string number)
        {
            var hasEvenNumberOfDigits = number.Length % 2 == 0;
            return  hasEvenNumberOfDigits ? number : PrependZero(number);
        }

        /// <summary>
        /// Ensures provided string stores number.
        /// </summary>
        /// <param name="number">String to test</param>
        /// <exception cref="ArgumentException">Throws exception when string has any non numeric char</exception>
        public static void EnsureNumber(string number)
        {
            if (!number.All(char.IsNumber) || string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Provided value is not a number");
            }
        }

        /// <summary>
        /// Gets the sum of two numbers using grade-school addition algorithm.
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns>String representation of a sum</returns>
        public static string GetSchoolAdditionSum(string numberOne, string numberTwo)
        {
            var x = numberOne.ToCharArray();
            var y = numberTwo.ToCharArray();

            var i = x.Length - 1;
            var overflow = 0;

            while (i >= 0)
            {
                var partialResult = CharToInt(x[i]) + CharToInt(y[i]) + overflow;
                var hasOverflow = partialResult > 9;

                overflow = hasOverflow ? 1 : 0;
                if (hasOverflow)
                {
                    partialResult %= 10;
                }

                x[i] = IntToChar(partialResult);
                i--;
            }

            if (overflow == 1)
            {
                return '1' + new string(x);
            }

            return new string(x);
        }

        private static int CharToInt(char digit)
        {
            return digit - '0';
        }

        private static char IntToChar(int digit)
        {
            return (char)(digit + '0');
        }

        private static string PrependZero(string x)
        {
            return x.Insert(0, "0");
        }

        private static string PrependZeros(this string text, int desiredTotalLength)
        {
            var currentLength = text.Length;
            var zerosToInsert = desiredTotalLength - currentLength;
            var zeros = new string(Enumerable.Range(0, zerosToInsert).Select(x => '0').ToArray());
            return text.Insert(0, zeros);
        }
    }
}
