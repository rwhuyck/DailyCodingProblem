using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_23
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Google.

            You are given an M by N matrix consisting of booleans that 
            represents a board. Each True boolean represents a wall. 
            Each False boolean represents a tile you can walk on.

            Given this matrix, a start coordinate, and an end coordinate, 
            return the minimum number of steps required to reach the 
            end coordinate from the start. If there is no possible path, 
            then return null. You can move up, left, down, and right. 
            You cannot move through walls. You cannot wrap around 
            the edges of the board.

            For example, given the following board:

            [[f, f, f, f],
            [t, t, f, t],
            [f, f, f, f],
            [f, f, f, f]]

            and start = (3, 0) (bottom left) and end = (0, 0) (top left), 
            the minimum number of steps required to reach the end is 7, 
            since we would need to go through (1, 2) because there is a wall 
            everywhere else on the second row.
            */

            bool[,] board =
            {
                {false, false, false, false },
                {true, true, false, true },
                {false, false, false, false },
                {false, false, false, false }
            };

            int startX = 3;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            int visitedX = startX;
            int visitedY = startY;
            int count = 0;

            bool keepGoing = true;
            while (keepGoing)
            {
                if (startX > endX)
                {
                    if (startX != 0 
                        && !board[startX - 1, startY]
                        && startX - 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX -= 1;
                        count++;
                    }
                    else if (startY != 0 
                        && !board[startX, startY - 1]
                        && startY - 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY -= 1;
                        count++;                        
                    }
                    else if (startY != board.GetUpperBound(1) - 1
                        && !board[startX, startY + 1]
                        && startY + 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY += 1;
                        count++;                        
                    }
                }
                else if (startX < endX)
                {
                    if (startX != board.GetUpperBound(0) - 1
                        && !board[startX + 1, startY]
                        && startX + 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX += 1;
                        count++;                        
                    }
                    else if (startY != 0
                        && !board[startX, startY - 1]
                        && startY - 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY -= 1;
                        count++;                        
                    }
                    else if (startY != board.GetUpperBound(1) - 1
                        && !board[startX, startY + 1]
                        && startY + 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY += 1;
                        count++;                        
                    }
                }
                else if (startY > endY)
                {
                    if (startY != 0
                        && !board[startX, startY - 1]
                        && startY - 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY -= 1;
                        count++;                        
                    }
                    else if (startX != 0
                        && !board[startX - 1, startY]
                        && startX - 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX -= 1;
                        count++;                        
                    }
                    else if (startX != board.GetUpperBound(1) - 1
                        && !board[startX + 1, startY]
                        && startX + 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX += 1;
                        count++;                        
                    }
                }
                else if (startY < endY)
                {
                    if (startY != board.GetUpperBound(0) - 1
                        && !board[startX, startY + 1]
                        && startY + 1 != visitedY)
                    {
                        visitedY = startY;
                        visitedX = -1;
                        startY += 1;
                        count++;                        
                    }
                    else if (startX != 0
                        && !board[startX - 1, startY]
                        && startX - 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX -= 1;
                        count++;                        
                    }
                    else if (startX != board.GetUpperBound(1) - 1
                        && !board[startX + 1, startY]
                        && startX + 1 != visitedX)
                    {
                        visitedX = startX;
                        visitedY = -1;
                        startX += 1;
                        count++;                        
                    }
                }

                if (count > (board.GetUpperBound(0) * board.GetUpperBound(1)) ||
                    startX == endX
                    && startY == endY)
                {
                    keepGoing = false;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
