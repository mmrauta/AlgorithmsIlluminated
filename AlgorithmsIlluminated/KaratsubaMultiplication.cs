using System;

namespace AlgorithmsIlluminated
{
    public static class KaratsubaMultiplication
    {
        /// <summary>
        /// Calculates multiplication of two numbers using Karatsuba method.
        /// </summary>
        /// <param name="x">String representation of a first number</param>
        /// <param name="y">String representation of a second number</param>
        /// <returns>Multiplication result</returns>
        public static int Calculate(string x, string y)
        {
            var (numberOne, numberTwo) = GetNumberRepresentations(x, y);
            var result = CalculateStep(numberOne, numberTwo);
            return result;
        }

        private static (string numberOne, string numberTwo) GetNumberRepresentations(string x, string y)
        {
            var firstNumber = AlgorithmsHelper.GetEvenDigitsNumber(x);
            var secondNumber = AlgorithmsHelper.GetEvenDigitsNumber(y);

            return AlgorithmsHelper.GetTheSameLengthNumbers(firstNumber, secondNumber);
        }

        private static int CalculateStep(string x, string y)
        {
            var (xMatchingLength, yMatchingLength) = AlgorithmsHelper.GetTheSameLengthNumbers(x, y);
            var numberLength = xMatchingLength.Length;

            if (numberLength == 1)
            {
                return int.Parse(x) * int.Parse(y);
            }

            var (a, b) = xMatchingLength.SplitHalf();
            var (c, d) = yMatchingLength.SplitHalf();

            var p = GetSum(a, b);
            var q = GetSum(c, d);

            var ac = CalculateStep(a, c);
            var bd = CalculateStep(b, d);
            var pq = CalculateStep(p, q);

            var adbc = pq - ac - bd;

            var result = Math.Pow(10, numberLength) * ac + Math.Pow(10, numberLength / 2) * adbc + bd;
            return (int)result;
        }

        private static (string, string) SplitHalf(this string text)
        {
            if (text.Length % 2 != 0)
            {
                throw new Exception("Can't split in a half number with odd number of digits!");
            }
            
            var length = text.Length / 2;
            return (text.Substring(0, length), text.Substring(length, length));
        }

        private static string GetSum(string x, string y)
        {
            return AlgorithmsHelper.GetSchoolAdditionSum(x, y);
        }
    }
}
