using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_32
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Jane Street.

            Suppose you are given a table of currency exchange rates, 
            represented as a 2D array. Determine whether there is a possible arbitrage: 
            that is, whether there is some sequence of trades you can make, 
            starting with some amount A of any currency, so that you can 
            end up with some amount greater than A of that currency.

            There are no transaction costs and you can trade fractional quantities. 
            */

            decimal[,] exchange =
            {   {1.00m, 4.00m, 5.00m, 6.00m },
                {0.25m, 1.00m, 4.00m, 1.70m },
                {0.20m, 0.25m, 1.00m, 1.30m },
                {0.16m, 0.59m, 0.77m, 1.00m }
            };

            decimal[,] exchange2 =
            {   {1.00m, 4.00m, 5.00m, 26.00m },
                {0.25m, 1.00m, 4.00m, 1.70m },
                {0.20m, 0.25m, 1.00m, 1.30m },
                {0.04m, 0.59m, 0.77m, 1.00m }
            };

            bool result = isArbitrage(exchange, 10.0m); //false
            bool result2 = isArbitrage(exchange2, 10.0m); //true

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadLine();
        }

        static private bool isArbitrage(decimal[,] exchange, decimal startingMoney)
        {
            int[] pathTally = new int[exchange.GetLength(0)];
            int firstCurrency = 0;
            decimal currentCash = startingMoney;
            bool isArbitrage = false;
            int counter = 0;

            for (int i = firstCurrency; i < exchange.GetLength(0); i++)
            {
                int maxIndex = 0;
                decimal max = 0.0m;
                int lastMaxIndex = 0;

                for (int j = 0; j < exchange.GetLength(1); j++)
                {
                    if (exchange[i, j] != 1.0m && max < exchange[i,j])
                    {
                        max = exchange[i,j];
                        lastMaxIndex = maxIndex;
                        maxIndex = j;
                    }
                }

                if (maxIndex == firstCurrency && 
                    currentCash * exchange[i, maxIndex] > startingMoney)
                {
                    isArbitrage = true;
                    break;
                }
                else
                {
                    if (!pathTally.Contains(maxIndex) && maxIndex != firstCurrency)
                    {
                        i = maxIndex - 1;
                        currentCash *= max;
                    }
                    else if (!pathTally.Contains(lastMaxIndex))
                    {
                        currentCash *= exchange[i, lastMaxIndex];
                        i = lastMaxIndex - 1;
                    }
                    else
                    {
                        currentCash *= exchange[i, firstCurrency];
                        if (currentCash > startingMoney)
                        {
                            isArbitrage = true;
                        }

                        break;
                    }
                }

                pathTally[counter] = i + 1;
                counter++;
            }

            return isArbitrage;
        }
    }
}
