using System;

namespace DailyCodingProblem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             This problem was recently asked by Google.

             Given a list of numbers and a number k, return whether any two numbers from 
             the list add up to k.

             For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

             Bonus: Can you do this in one pass?
             */

            int[] input = { 10, 15, 3, 7 };
            int k = 17;
            //int[] sums = new int[input.Length];
            bool isSum = false;

            //First try
            //for (int i = 0; i < sums.Length; i++)
            //{
            //    for (int j = 0; j < input.Length; j++)
            //    {
            //        sums[i] = input[i] + input[j];

            //        if (sums[i] == k)
            //        {
            //            isSum = true;
            //            break;
            //        }
            //    }
            //}

            //Second try
            for (int i = 0; i < input.Length; i++)
            {
                int component = k - input[i];
                if (Array.IndexOf(input, component) != -1)
                {
                    isSum = true;
                }
            }

            Console.WriteLine(isSum.ToString());
            Console.ReadLine();
        }
    }
}
