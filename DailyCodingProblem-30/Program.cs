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
            int[] input4 = { 2, 0, 6, 2, 4, 1, 7, 1, 2 }; //14
            int[] input5 = { 7, 6, 4, 2, 1, 0 }; //0
            int[] input6 = { 0, 2, 5, 7, 8, 9 }; //0
            int[] input7 = { 6, 2, 4, 1, 3 }; //4
            int[] input8 = { 3, 1, 4, 2, 6 }; //4
            Console.WriteLine(totalVolume(input));
            Console.WriteLine(totalVolume(input2));
            Console.WriteLine(totalVolume(input3));
            Console.WriteLine(totalVolume(input4));
            Console.WriteLine(totalVolume(input5));
            Console.WriteLine(totalVolume(input6));
            Console.WriteLine(totalVolume(input7));
            Console.WriteLine(totalVolume(input8));

            Console.ReadLine();
        }

        private static int totalVolume(int[] input)
        {
            int max = 0;
            int localMax = 0;
            int volume = 0;
            int segmentVolume = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0)
                {
                    //Save the volume of the fully contained, edge-including segment,
                    //and restart volume counting
                    if (input[i] >= input[max])
                    {
                        volume = localVolume(input, max, i);
                        segmentVolume += volume;
                        volume = 0;
                        max = i;
                        localMax = i;
                    }
                    //Move to the next local "descending" peak, and build volume
                    else if (input[i] > input[i - 1] &&
                        input[i] < input[localMax])
                    {
                        volume += localVolume(input, localMax, i);
                        localMax = i;
                    }
                    //Aggregate volume of locally contained area
                    else if (input[i] > input[localMax] &&
                        input[i] < input[max])
                    {
                        volume = localVolume(input, max, i);
                        localMax = i;
                    }  
                }
            }

            return volume + segmentVolume;
        }

        private static int localVolume(int[] input, int start, int end)
        {
            int volume = 0;
            int limit;

            if (input[start] >= input[end])
            {
                limit = input[end];
            }
            else
            {
                limit = input[start];
            }

            for (int i = start + 1; i < end; i++)
            {
                if (input[i] < limit)
                {
                    volume += limit - input[i];
                }               
            }

            return volume;
        }
    }
}
