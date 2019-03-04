using System;
using System.Linq;

namespace AlgorithmsIlluminated
{
    public static class BasicAlgorithmsHelper
    {
        public static int CalculateKaratsubaMultiplication(string x, string y)
        {
            (string numberOne, string numberTwo) = GetNumberRepresentations(x, y);
            var result = CalculateStep(numberOne, numberTwo);
            return result;
        }

        private static (string numberOne, string numberTwo) GetNumberRepresentations(string x, string y)
        {
            var firstNumber = GetNumberRepresentation(x);
            var secondNumber = GetNumberRepresentation(y);

            if (firstNumber.Length != secondNumber.Length)
            {
                return firstNumber.Length > secondNumber.Length
                       ? (firstNumber, secondNumber.PrependZeros(firstNumber.Length))
                       : (firstNumber.PrependZeros(secondNumber.Length), secondNumber);
            }

            return (firstNumber, secondNumber);
        }

        private static int CalculateStep(string x, string y)
        {
            var numberLength = x.Length;
            if (numberLength == 1)
            {
                return int.Parse(x) * int.Parse(y);
            }

            (var a, var b) = x.SplitHalf();
            (var c, var d) = y.SplitHalf();

            var p = GetSum(a, b);
            var q = GetSum(c, d);

            var ac = CalculateStep(a, c);
            var bd = CalculateStep(b, d);
            var pq = CalculateStep(p, q);

            var adbc = pq - ac - bd;

            var result = Math.Pow(10, numberLength) * ac + Math.Pow(10, numberLength / 2) * adbc + bd;
            return (int)result;
        }

        private static string GetNumberRepresentation(string x)
        {
            if (!x.All(char.IsNumber))
            {
                throw new ArgumentException("Provided data is not a number");
            }

            return x.Length % 2 == 0 ? x : x.Insert(0, "0");
        }

        private static (string, string) SplitHalf(this string text)
        {
            var length = text.Length / 2;
            return (text.Substring(0, length), text.Substring(length, length));
        }

        private static string PrependZeros(this string text, int desiredLength)
        {
            var currentLength = text.Length;
            var zerosToInsert = desiredLength - currentLength;
            var zeros = new string(Enumerable.Range(0, zerosToInsert).Select(x => '0').ToArray());
            return text.Insert(0, zeros);
        }

        private static string GetSum(string x, string y)
        {
            var firstNumber = x.ToCharArray();
            var secondNumber = y.ToCharArray();

            var i = firstNumber.Length - 1;
            var overflow = false;
            while (i >= 0)
            {
                var partialResult = firstNumber[i] -'0' + secondNumber[i] - '0';
                if (overflow)
                {
                    partialResult++;
                }

                if (partialResult > 9)
                {
                    overflow = true;
                    partialResult %= 10;
                }
                else
                {
                    overflow = false;
                }

                firstNumber[i] = (char)(partialResult + '0');
                i--;
            }

            return new string(firstNumber);
        }
    }
}
