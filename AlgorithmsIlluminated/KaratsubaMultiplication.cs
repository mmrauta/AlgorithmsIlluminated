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
            AlgorithmsHelper.EnsureNumber(x);
            AlgorithmsHelper.EnsureNumber(y);

            var result = CalculateStep(x, y);
            return result;
        }

        private static (string numberOne, string numberTwo, int length) GetNumberRepresentations(string x, string y)
        {
            var firstNumber = AlgorithmsHelper.GetEvenDigitsNumber(x);
            var secondNumber = AlgorithmsHelper.GetEvenDigitsNumber(y);

            var (first, second) = AlgorithmsHelper.GetTheSameLengthNumbers(firstNumber, secondNumber);
            return (first, second, first.Length);
        }

        private static int CalculateStep(string x, string y)
        {
            if (x.Length == 1 && y.Length == 1)
            {
                return int.Parse(x) * int.Parse(y);
            }

            var (xEvenLength, yEvenLength, numbersLength) = GetNumberRepresentations(x, y);

            var (a, b) = xEvenLength.SplitHalf();
            var (c, d) = yEvenLength.SplitHalf();

            var p = GetSum(a, b);
            var q = GetSum(c, d);

            var ac = CalculateStep(a, c);
            var bd = CalculateStep(b, d);
            var pq = CalculateStep(p, q);

            var adbc = pq - ac - bd;

            var result = Math.Pow(10, numbersLength) * ac + Math.Pow(10, numbersLength / 2) * adbc + bd;
            return (int)result;
        }

        private static (string, string) SplitHalf(this string text)
        {
            if (text.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException(text,"Can't split half a text with odd number of digits!");
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
