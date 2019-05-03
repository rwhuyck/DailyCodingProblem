using System;

namespace DailyCodingProblem_04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*his problem was asked by Stripe.

            Given an array of integers, find the first missing positive integer 
            in linear time and constant space. In other words, find 
            //the lowest positive integer that does not exist in the array. 
            //The array can contain duplicates and negative numbers as well.

            For example, the input [3, 4, -1, 1] should give 2. 
            The input [1, 2, 0] should give 3.

            You can modify the input array in-place.
            */

            int[] input = { 3, 4, -1, 1 }; //returns 2
            //int[] input = { 1, 2, 0 }; //returns 3
            //int[] input = { -3, -1, 0, 1, -241, 23, 2, 6, 3, 7, 5, -5 }; //returns 4
            //int[] input = {}; //Or [0, 0, 0, 0]. returns 1
            //int[] input = { 1, 2, 3, 4, 5, 6, 7 }; //returns 8
            //int[] input = { 5, 5, -3, -1, 0, 0, 4, 1, 2, 1, 2, 1, 2 }; //returns 3
            int result = findInteger(input);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        //Sort array to be ascending, then start searching for missing number 
        //starting at 1. O(n) in time and space.
        static internal int findInteger(int[] input)
        {
            Array.Sort(input);
            int flag = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 0)
                {
                    if (flag != input[i])
                    {
                        return flag;
                    }
                    else if (i + 1 >= input.Length)
                    {
                        flag++;
                    }
                    else if (input[i + 1] != input[i])
                    {
                        flag++;
                    }
                }
            }
            return flag;
        }
    }
}
