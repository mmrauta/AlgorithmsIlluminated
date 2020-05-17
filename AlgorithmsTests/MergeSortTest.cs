using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsTests
{
    public class MergeSortTest
    {
        [Theory]
        [InlineData(",,,,1,2,,,,,,3,9,8,7", new[] {1, 2, 3, 7, 8, 9})]
        [InlineData("test,1,2,3,4,5,abc,6", new[] {1, 2, 3, 4, 5, 6})]
        [InlineData("test,abc.xyz", new int[] { })]
        public void Ignore_Non_Numeric_Characters(string numbers, int[] expectedResult)
        {
            var result = MergeSort.Sort(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,3,9,8,7", new[] {1, 2, 3, 7, 8, 9})]
        [InlineData("1,2,3,4,5,6", new[] {1, 2, 3, 4, 5, 6})]
        [InlineData("0,0,0", new[] {0, 0, 0})]
        [InlineData("22,100,1,0,1", new[] {0, 1, 1, 22, 100})]
        [InlineData("22,100,1,0,1, 1234567", new[] { 0, 1, 1, 22, 100, 1234567 })]
        public void Sort_Numeric_Values(string numbers, int[] expectedResult)
        {
            var result = MergeSort.Sort(numbers);
            Assert.Equal(expectedResult, result);
        }
    }
}