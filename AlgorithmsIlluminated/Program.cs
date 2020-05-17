using System;
using System.Linq;

namespace AlgorithmsIlluminated
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Multiplication using Karatsuba multiplication algorithm");
            //Console.WriteLine("Please enter two comma separated numbers:");

            Console.WriteLine("Merge sort algorithm");
            Console.WriteLine("Please enter comma separated numbers:");

            var numbers = Console.ReadLine();

            try
            {
                //var result = KaratsubaMultiplication.Sort(numbers[0], numbers[1]);
                var result = MergeSort.Sort(numbers);

                Console.WriteLine($"Result is {string.Join(',', result)}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}.");
            }
            finally
            {
                Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
