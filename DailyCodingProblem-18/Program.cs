using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_18
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Google.

            Given an array of integers and a number k, 
            where 1 <= k <= length of the array, 
            compute the maximum values of each subarray of length k.

            For example, given array = [10, 5, 2, 7, 8, 7]
            and k = 3, we should get: [10, 7, 8, 8], since:

                10 = max(10, 5, 2)
                7 = max(5, 2, 7)
                8 = max(2, 7, 8)
                8 = max(7, 8, 7)

            Do this in O(n) time and O(k) space. 
            You can modify the input array in-place 
            and you do not need to store the results. 
            You can simply print them out as you compute them.
            */

            int[] input = { 10, 5, 2, 7, 8, 7 };
            int subLength = 3;
            int[] subArray = new int[subLength];

            for (int i = 0; i < input.Length - subLength + 1; i++)
            {
                Array.Copy(input, i, subArray, 0, subLength);
                Console.WriteLine(subArray.Max());
            }

            Console.ReadLine();
        }
    }
}
