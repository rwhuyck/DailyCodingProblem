using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_12
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Amazon.

            There exists a staircase with N steps, and you can climb up either 
            1 or 2 steps at a time. Given N, write a function that returns the 
            number of unique ways you can climb the staircase. The order of 
            the steps matters.

            For example, if N is 4, then there are 5 unique ways:

                1, 1, 1, 1
                2, 1, 1
                1, 2, 1
                1, 1, 2
                2, 2

            What if, instead of being able to climb 1 or 2 steps at 
            a time, you could climb any number from a set of positive 
            integers X? For example, if X = {1, 3, 5}, you could 
            climb 1, 3, or 5 steps at a time.
            */

            int[] steps = { 1, 2 }; // Returns 5
            //int[] steps = { 1, 3, 5 }; // Returns 3
            int stairs = 4;
            int resultRecursive = RecursiveWaysClimbable(steps, stairs);
            int resultDynamic = DynamicWaysClimable(steps, stairs);

            Console.WriteLine(resultRecursive);
            Console.WriteLine(resultDynamic);
            Console.ReadLine();
        }

        static int RecursiveWaysClimbable(int[] steps, int stairs)
        {
            int result = 0;
            if (stairs == 0)
            {
                result++; // can be 0, just depends on if you count 0 stairs as real
            }
            else if (stairs == 1)
            {
                result++;
            }
            else
            {
                foreach (int step in steps)
                {
                    if (stairs >= step)                  
                    {
                        result += RecursiveWaysClimbable(steps, stairs - step);
                    }
                }
            }
            return result;
        }

        static int DynamicWaysClimable(int[] steps, int stairs)
        {
            if (stairs == 0)
            {
                return 1;
            }

            int[] ways = new int[stairs + 1];
            ways[0] = 1;

            for (int i = 1; i < ways.Length; i++)
            {
                int total = 0;
                foreach (int step in steps)
                {
                    if (i - step >= 0)
                    {
                        total += ways[i - step];
                    }
                }
                ways[i] = total;
            }
            return ways[stairs];
        }
    }
}
