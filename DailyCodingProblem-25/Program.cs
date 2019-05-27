using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_25
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Facebook.

            Implement regular expression matching with the following special characters:

                . (period) which matches any single character
                * (asterisk) which matches zero or more of the preceding element

            That is, implement a function that takes in a string and a valid 
            regular expression and returns whether or not the string matches 
            the regular expression.

            For example, given the regular expression "ra." and the string "ray", 
            your function should return true. The same regular expression on the 
            string "raymond" should return false.

            Given the regular expression ".*at" and the string "chat", 
            your function should return true. The same regular expression on 
            the string "chats" should return false.
            */

            string[] words = { "raymond", "ray", "chat", "chats" };
            string search1 = "ra.";
            string search2 = ".*at";

            Console.WriteLine(RegExpMatch(search1, words));
            Console.WriteLine(RegExpMatch(search2, words));
            Console.ReadLine();
        }

        static string RegExpMatch(string search, string[] words)
        {
            bool match = false;
            string cache = "";
            string matchedWord = "";
            int index = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for (int j = 0; j < word.Length; j++)
                {
                    if (index == search.Length)
                    {
                        break;
                    }
                    if (search[index] == '.')
                    {
                        cache += word[j];
                        index++;
                    }
                    else if (search[index] == word[j])
                    {
                        cache += word[j];
                        index++;
                    }
                    else if (search[index] == '*')
                    {
                        cache += word[j];

                        if (index + 1 >= search.Length)
                        {
                            continue;
                        }
                        else if (j+1 < word.Length)
                        {
                            if (search[index + 1] == word[j + 1] ||
                                search[index + 1] == '.')
                            {
                                index++;
                            }                            
                        }
                    }
                }

                if (word == cache)
                {
                    match = true;
                    matchedWord = cache;
                }

                cache = "";
                index = 0;
            }

            return match.ToString() + ": " + matchedWord;
        }
    }    
}
