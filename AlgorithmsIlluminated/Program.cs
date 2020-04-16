using System;

namespace AlgorithmsIlluminated
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiplication using Karatsuba multiplication algorithm");
            Console.WriteLine("Please enter two comma separated numbers:");

            var numbers = Console.ReadLine().Split(",");

            try
            {
                var result = KaratsubaMultiplication.Calculate(numbers[0], numbers[1]);
                Console.WriteLine($"Result is {result}.");
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
