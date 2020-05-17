using System.Linq;

namespace AlgorithmsIlluminated
{
    public static class MergeSort
    {
        /// <summary>
        /// Sorts the array of numbers using the Merge Sort algorithm.
        /// </summary>
        /// <param name="numbersInput">String storing comma separated integers.</param>
        /// <returns>Array of sorted numbers.</returns>
        public static int[] Sort(string numbersInput)
        {
            var numbers = GetNumbers(numbersInput);
            var result = SortStep(numbers);
            return result;
        }

        private static int[] SortStep(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }
            
            var (first, second) = SplitHalf(numbers);

            var firstCalculated = SortStep(first);
            var secondCalculated = SortStep(second);

            var merged = Merge(firstCalculated, secondCalculated);
            return merged;
        }

        private static int[] GetNumbers(string numbers)
        {
            var numbersSet = numbers
                .Split(",")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse);

            return numbersSet.ToArray();
        }

        private static int[] Merge(int[] firstSet, int[] secondSet)
        {
            var totalLength = firstSet.Length + secondSet.Length;
            var result = new int[totalLength];

            for (int iResult = 0, iOne = 0, iTwo = 0; iResult < totalLength; iResult++)
            {
                if (TableEndReached(firstSet, iOne))
                {
                    return AppendTheRest(result, iResult, secondSet[iTwo..]);
                }

                if (TableEndReached(secondSet, iTwo))
                {
                    return AppendTheRest(result, iResult, firstSet[iOne..]);
                }

                result[iResult] = firstSet[iOne] < secondSet[iTwo]
                            ? firstSet[iOne++]
                            : secondSet[iTwo++];
            }

            return result;
        }

        private static bool TableEndReached(int[] set, int index)
        {
            return set.Length == index;
        }

        private static int[] AppendTheRest(int[] result, int resultPosition, int[] set)
        {
            for (int i = resultPosition, j = 0; i < result.Length; i++, j++)
            {
                result[i] = set[j];
            }

            return result;
        }

        private static (int[], int[]) SplitHalf(this int[] set)
        {
            var length = set.Length / 2;
            return (set[..length], set[length..]);
        }
    }
}
