using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_19
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Facebook.

            A builder is looking to build a row of N houses that 
            can be of K different colors. He has a goal of minimizing cost 
            while ensuring that no two neighboring houses are of the same color.

            Given an N by K matrix where the nth row and kth column 
            represents the cost to build the nth house with kth color, 
            return the minimum cost which achieves this goal. 
            */

            //Solution based on python solution here: 
            //https://github.com/vineetjohn/daily-coding-problem/blob/master/solutions/problem_019.py

            int[,] costs = 
                {{1, 2, 4, 5 },
                {1, 3, 6, 5 },
                {9, 4, 3, 7 }};

            int prev_row_min = 0;
            int prev_row_min_index = -1;
            int prev_row_second_min = 0;
            int min = int.MaxValue;

            for (int i = 0;  i < costs.GetLength(0); i++)
            {


                int curr_row_min = int.MaxValue;
                int curr_row_second_min = int.MaxValue;
                int curr_row_min_index = 0;

                for (int j = 0; j < costs.GetLength(1); j++)
                {
                    if (prev_row_min_index == j)
                    {
                        costs[i, j] += prev_row_second_min;
                    }
                    else
                    {
                        costs[i, j] += prev_row_min;
                    }

                    if (curr_row_min > costs[i, j])
                    {

                        curr_row_second_min = curr_row_min;
                        curr_row_min = costs[i, j];
                        curr_row_min_index = j;
                    }
                    else if (curr_row_second_min > costs[i, j])
                    {
                        curr_row_second_min = costs[i, j];
                    }
                        
                }

                prev_row_min = curr_row_min;
                prev_row_second_min = curr_row_second_min;
                prev_row_min_index = curr_row_min_index;
            }

            for (int j = 0; j < costs.GetLength(1); j++)
            {
                int temp = Enumerable.Range(0, costs.GetLength(0))
                .Select(i => costs[costs.GetLength(0) - 1, j]).Min();

                if (temp < min)
                {
                    min = temp;
                }
            }            

            Console.WriteLine(min); 
            Console.ReadLine();
        }
    }
}
