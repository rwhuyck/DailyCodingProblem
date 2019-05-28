using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_27
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Facebook.

            Given a string of round, curly, and square open and closing brackets, 
            return whether the brackets are balanced (well-formed).

            For example, given the string "([])[]({})", you should return true.

            Given the string "([)]" or "((()", you should return false.
            */

            string input1 = "([])[]({})";
            string input2 = "([)]";
            string input3 = "((()";
            string input4 = "))[)]";

            Console.WriteLine(WellFormed(input1));
            Console.WriteLine(WellFormed(input2));
            Console.WriteLine(WellFormed(input3));
            Console.WriteLine(WellFormed(input4));

            Console.ReadLine();
        }

        static bool WellFormed(string input)
        {
            bool wellFormed = false;
            Stack cache = new Stack();
            int count = 0;

            foreach (char item in input)
            {
                switch (item)
                {
                    case '(':
                        cache.Push(item);
                        break;
                    case '[':
                        cache.Push(item);
                        break;
                    case '{':
                        cache.Push(item);
                        break;
                    default:
                        break;
                }

                try
                {
                    switch (item)
                    {
                        case ')':
                            if ((char)cache.Pop() == '(')
                            {
                                count++;
                            }
                            break;
                        case ']':
                            if ((char)cache.Pop() == '[')
                            {
                                count++;
                            }
                            break;
                        case '}':
                            if ((char)cache.Pop() == '{')
                            {
                                count++;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException)
                {
                    return wellFormed;
                }
            }

            if (count == input.Length/2)
            {
                wellFormed = true;
            }

            return wellFormed;
        }
    }
}
