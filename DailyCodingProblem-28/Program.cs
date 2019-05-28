using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_28
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Palantir.

            Write an algorithm to justify text. 
            Given a sequence of words and an integer line length k, 
            return a list of strings which represents each line, 
            fully justified.

            More specifically, you should have as many words 
            as possible in each line. There should be at least 
            one space between each word. Pad extra spaces when 
            necessary so that each line has exactly length k. 
            Spaces should be distributed as equally as possible, 
            with the extra spaces, if any, distributed starting from the left.

            If you can only fit one word on a line, 
            then you should pad the right-hand side with spaces.

            Each word is guaranteed not to be longer than k.

            For example, given the list of words 
            ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] 
            and k = 16, you should return the following:

            ["the  quick brown", # 1 extra space on the left
            "fox  jumps  over", # 2 extra spaces distributed evenly
            "the   lazy   dog"] # 4 extra spaces distributed evenly
            */

            string[] input = { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            int k = 16;

            string[] result = Justified(input, k);

            foreach (string line in result)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();

        }

        static string[] Justified(string[] input, int k)
        {
            string[] temp = new string[input.Length];
            string[] justified = new string[0];
            int counter = k;
            int place = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (counter - input[i].Length >= 0)
                {
                    //Add space to all but last word in line
                    if (i + 1 < input.Length &&
                        counter - (input[i].Length + input[i+1].Length) > 0)
                    {
                        temp[i] += input[i] + " ";
                        counter -= input[i].Length + 1;
                    }
                    else
                    {
                        temp[i] += input[i];
                        counter -= input[i].Length;
                    }
                }

                //When new word can't fit in line limit, or at end of input,
                //add spaces until line limit reached.
                if ((i+1 == input.Length || counter - input[i].Length < 0) &&
                    counter != 0)
                {
                    while (counter != 0)
                    {
                        for (int j = place; j < i; j++)
                        {
                            if (counter != 0)
                            {
                                temp[j] += " ";
                                counter--;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                //Assemble fragmented line into result array as single line
                if (counter == 0)
                {
                    Array.Resize(ref justified, justified.Length + 1);
                    counter = k;

                    for (int j = place; j <= i; j++)
                    {
                        justified[justified.GetUpperBound(0)] += temp[j];
                    }

                    place = i + 1;
                }
            }

            return justified;
        }
    }
}
