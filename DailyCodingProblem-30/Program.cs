using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_30
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Facebook.

            You are given an array of non-negative integers that represents 
            a two-dimensional elevation map where each element is unit-width 
            wall and the integer is the height. Suppose it will rain and all 
            spots between two walls get filled up.

            Compute how many units of water remain trapped on the map in 
            O(N) time and O(1) space.

            For example, given the input [2, 1, 2], we can hold 1 unit of 
            water in the middle.

            Given the input [3, 0, 1, 3, 0, 5], we can hold 3 units in the 
            first index, 2 in the second, and 3 in the fourth index 
            (we cannot hold 5 since it would run off to the left), 
            so we can trap 8 units of water.
            */

            int[] input = { 3, 0, 1, 3, 0, 5 }; //8
            int[] input2 = { 5, 1, 6, 3, 2, 4 }; //7
            int[] input3 = { 3, 0, 2, 7, 0, 5 }; //9
            Console.WriteLine(volume(input));
            Console.WriteLine(volume(input2));
            Console.WriteLine(volume(input3));

            Console.ReadLine();
        }

        private static int volume(int[] input)
        {
            //int limit = edgeLimit(input);
            int limit;
            int firstEdge = input[0];
            int secondEdge = input[input.Length - 1];
            int volume = 0;

            if (firstEdge <= secondEdge)
            {
                limit = firstEdge;
            }
            else
            {
                limit = secondEdge;
            }           

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < limit)
                {
                    volume += limit - input[i];
                }
                else if (input[i] > limit && i != 0 && 
                    secondEdge < firstEdge)
                {
                    volume = 0;

                    for (int j = 0; j < i; j++)
                    {
                        if (input[j] < firstEdge)
                        {
                            volume += firstEdge - input[j];
                        }
                    }
                }
                else if (input[i] > limit &&
                    secondEdge > firstEdge &&
                    input[i] > secondEdge)
                {
                    limit = secondEdge;
                }
            }

            return volume;
        }
    }
}
