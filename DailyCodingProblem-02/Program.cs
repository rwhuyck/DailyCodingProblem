using System;
using System.Linq;

namespace DailyCodingProblem_02
{
    class Program
    {
        static void Main(string[] args)
        {
            /*This problem was asked by Uber.

            Given an array of integers, return a new array such that
            each element at index i of the new array is the product
            of all the numbers in the original array except the one at i.

            For example, if our input was [1, 2, 3, 4, 5], the expected output 
            would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], 
            the expected output would be [2, 3, 6].

            Follow-up: what if you can't use division?
            */

            //Solving the problem without division (with division would be more like
            //the first problem as a solution).

            //int[] input = { 1, 2, 3, 4, 5 };
            int[] input = { 3, 2, 1 };
            int[] product = Enumerable.Repeat(1, input.Length).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (j != i)
                    {
                        product[i] *= input[j];
                    }
                }
            }

            foreach (int item in product)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
