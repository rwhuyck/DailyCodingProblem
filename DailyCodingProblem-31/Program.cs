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
            int j = 0, lessChars = 0;
            int i;

            //Difference in lengths means we already know number of inserts/deletions needed
            int distance = Math.Abs(output.Length - input.Length);

            for (i = 0; i < input.Length; i++)
            {
                if (j < output.Length)
                {
                    //Do nothing except move index if char's already equal
                    if (input[i] == output[j])
                    {
                        j++;
                    }
                    //If one char is off, but next is correct, tally diff and move index
                    else if (i + 1 < input.Length && j + 1 < output.Length &&
                        input[i + 1] == output[j + 1])
                    {
                        distance++;
                        j++;
                    }
                    //If extra chars in input, jump i past them and continue
                    else if (j + 1 < output.Length &&
                        input.Contains(output[j]) &&
                        input[input.IndexOf(output[j], i) + 1] == output[j + 1])
                    {
                        j++;
                        i = input.IndexOf(output[j], i);
                    }
                    //If extra chars in output, jump j past them and continue
                    else if (i + 1 < input.Length && 
                        !input.Contains(output[j]) &&
                        output[output.IndexOf(input[i], j) + 1] == input[i + 1])
                    {
                        
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

            //if (i != (j + 1) && j < output.Length)
            //{
            //    distance += Math.Abs(output.Length - i);
            //}
            //else if (lessChars < input.Length && lessChars > 0)
            //{
            //    distance += Math.Abs(input.Length - lessChars);
            //}

            return distance;
        }
    }
}
