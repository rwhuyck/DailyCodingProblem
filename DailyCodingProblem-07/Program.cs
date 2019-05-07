using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DailyCodingProblem_07
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *This problem was asked by Facebook.

            Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, 
            count the number of ways it can be decoded.

            For example, the message '111' would give 3, 
            since it could be decoded as 'aaa', 'ka', and 'ak'.

            You can assume that the messages are decodable. 
            For example, '001' is not allowed. 
             */

            int input = 111; //returns 3
            //int input = 21145; //returns 5
            //int input = 1113225; //returns 15
            //int input = 1422; //returns 4

            Console.WriteLine(WaysDecoded(input));
            Console.ReadLine();
        }

        static int WaysDecoded(int input)
        {
            int result = 0;
            string remaining = input.ToString();

            if (remaining.Length == 1)
            {
                result++;
            }
            else if (remaining.Length == 2)
            {
                result++;
                if (input <= 26 && input >= 1)
                {
                    result++;
                }
            }
            else
            {
                result = WaysDecoded(int.Parse(remaining.Substring(1)));
                if (int.Parse(remaining.Substring(0, 2)) <= 26
                    && int.Parse(remaining.Substring(0, 2)) >= 1)
                {
                    result += WaysDecoded(int.Parse(remaining.Substring(2)));
                }
            }

            return result;
        }
    }
}
