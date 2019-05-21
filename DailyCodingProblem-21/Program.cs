using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_21
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Snapchat.

            Given an array of time intervals (start, end) for classroom 
            lectures (possibly overlapping), find the minimum number of rooms required.

            For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
            */

            int[][] classes = { 
                new int[] { 30, 75 },
                new int[] { 0, 50 },
                new int[] { 60, 150 } };
            int rooms = 0;

            //Sort the array rows by ascending
            classes = classes.OrderBy(row => row.Min()).ToArray();

            for (int i = 0; i < classes.GetLength(0) - 1; i++)
            {
                if (classes[i][1] >= classes[i + 1][0])
                {
                    rooms++;
                }
            }

            //There must always be one room to hold classes in.
            if (rooms == 0)
            {
                rooms++;
            }

            Console.WriteLine(rooms);
            Console.ReadLine();
        }
    }
}
