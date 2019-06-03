using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem31
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Google.

            The edit distance between two strings refers to the minimum number 
            of character insertions, deletions, and substitutions required to 
            change one string to the other. For example, the edit distance 
            between “kitten” and “sitting” is three: substitute the “k” for “s”, 
            substitute the “e” for “i”, and append a “g”.

            Given two strings, compute the edit distance between them. 
            */

            string input = "kitten";
            string output = "sitting"; //3
            string output2 = "kitchen"; //2
            string output3 = "kit"; //3

            Console.WriteLine(editDistance(input, output));
            Console.WriteLine(editDistance(input, output2));
            Console.WriteLine(editDistance(input, output3));
            Console.ReadLine();
        }

        static int editDistance(string input, string output)
        {
            int distance = 0;
            int j = 0, lessChars = 0;
            int i;
            
            for (i = 0; i < input.Length; i++)
            {
                if (j < output.Length)
                {
                    if (input[i] == output[j])
                    {
                        j++;
                    }
                    else if (i + 1 < input.Length && j + 1 < output.Length &&
                        input[i + 1] == output[j + 1])
                    {
                        distance++;
                        j++;
                    }
                    else if (j + 1 < output.Length &&
                        input.Contains(output[j]) &&
                        input[input.IndexOf(output[j], i) + 1] == output[j + 1])
                    {
                        distance ++;
                        j++;
                        i = input.IndexOf(output[j], i);
                    }
                    else if (i + 1 < input.Length && j + 1 < output.Length &&
                        !input.Contains(output[j]) &&
                        output[output.IndexOf(input[i], j) + 1] == input[i + 1])
                    {
                        distance ++;
                        j = output.IndexOf(input[i], j) + 1;
                    }
                    else
                    {
                        distance++;
                        j++;
                    }
                }
                else
                {
                    lessChars = Math.Abs(input.Length - j);
                }
            }

            if (i != (j + 1) && j < output.Length)
            {
                distance += Math.Abs(output.Length - i);
            }
            else if (lessChars < input.Length && lessChars > 0)
            {
                distance += Math.Abs(input.Length - lessChars);
            }

            return distance;
        }
    }
}
