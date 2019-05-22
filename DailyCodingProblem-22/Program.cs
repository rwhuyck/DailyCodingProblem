using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_22
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Microsoft.

            Given a dictionary of words and a string made up of those words (no spaces), 
            return the original sentence in a list. If there is more than one
            possible reconstruction, return any of them. If there is no possible 
            reconstruction, then return null.

            For example, given the set of words 'quick', 'brown', 'the', 'fox', 
            and the string "thequickbrownfox", you should return ['the', 'quick', 'brown', 'fox'].

            Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', 
            and the string "bedbathandbeyond", return either ['bed', 'bath', 'and', 'beyond] 
            or ['bedbath', 'and', 'beyond'].
            */

            string[] dictionary = { "quick", "brown", "the", "fox",
                "bed", "bath", "bedbath", "and", "beyond" };
            string input1 = "thequickbrownfox";
            string input2 = "bedbathandbeyond";

            string[] result = Parse(input1, dictionary);
            string[] result2 = Parse(input2, dictionary);

            foreach (string word in result)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            foreach (string word in result2)
            {
                Console.Write(word + " ");
            }

            Console.ReadLine();
        }

        static string[] Parse(string input, string[] dictionary)
        {
            string[] result = new string[0];
            string temp = "";

            for (int i = 0; i < input.Length; i++)
            {
                temp += input[i];

                if (dictionary.Contains(temp))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.GetUpperBound(0)] = temp;
                    temp = "";
                }
            }

            return result;
        }
    }
}
