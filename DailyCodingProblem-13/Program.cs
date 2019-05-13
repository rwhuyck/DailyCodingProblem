using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_13
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Amazon.

            Given an integer k and a string s, find the length 
            of the longest substring that contains at most k distinct characters.

            For example, given s = "abcba" and k = 2, the longest 
            substring with k distinct characters is "bcb". 
            */

            string input = "abcba";
            int distinct = 2;

            string result = DistinctCharactersString(input, distinct);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static string DistinctCharactersString(string input, int distinct)
        {
            string result = "";
            string temp = "";
            string temp2 = "";
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!temp.Contains(input[i]))
                {
                    counter++;
                }
                if (counter <= distinct)
                {
                    temp += input[i];
                }
                else if (i > 1)
                {
                    temp = "";
                    counter = 0;
                    temp2 = DistinctCharactersString(input.Substring(i - 1), distinct);
                }

                if (result.Length < temp.Length)
                {
                    result = temp;
                }
                else if (result.Length < temp2.Length)
                {
                    result = temp2;
                }
            }
            return result;
        }
    }
}
