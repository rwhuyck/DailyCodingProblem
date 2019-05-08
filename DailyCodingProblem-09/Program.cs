using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_09
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This problem was asked by Airbnb.

               Given a list of integers, write a function that returns the largest 
               sum of non-adjacent numbers. Numbers can be 0 or negative.

               For example, [2, 4, 6, 2, 5] should return 13, since we pick 
               2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.

               Follow-up: Can you do this in O(N) time and constant space?
            */

            //int[] input = { 2, 4, 6, 2, 5 }; // Returns 13
            int[] input = { 5, 1, 1, 5 }; // Returns 10
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum1 += input[i];

                if (i + 2 >= input.Length)
                {
                    break;
                }
                else if (i + 3 >= input.Length)
                {
                    i += 1;
                }
                else if (input[i + 3] > input[i + 2])
                {
                    i = i + 2;
                }
                else if (input[i + 2] > input[i + 3])
                {
                    i = i + 1;
                }
            }

            for (int i = 1; i < input.Length; i++)
            {
                sum2 += input[i];

                if (i + 2 >= input.Length)
                {
                    break;
                }
                else if (i + 3 >= input.Length)
                {
                    i += 1;
                }
                else if (input[i + 3] > input[i + 2])
                {
                    i = i + 2;
                }
                else if (input[i + 2] > input[i + 3])
                {
                    i = i + 1;
                }
            }

            if (sum1 > sum2)
            {
                Console.WriteLine(sum1);
            }
            else
            {
                Console.WriteLine(sum2);
            }

            Console.ReadLine();
        }
    }
}
