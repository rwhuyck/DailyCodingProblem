using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_11
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               Implement an autocomplete system. That is, given a query 
               string s and a set of all possible query strings, return 
               all strings in the set that have s as a prefix.

               For example, given the query string de and the set of 
               strings [dog, deer, deal], return [deer, deal].

               Hint: Try preprocessing the dictionary into a more 
               efficient data structure to speed up queries.
             */
            string stub = "de";
            var dictionary = new List<string>{"deer", "duck", "deal", "dog", "cat", "drunk"};
            string[] suggestions = Autocomplete(dictionary, stub);
            foreach (string s in suggestions)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        static string[] Autocomplete(List<string> dictionary, string stub)
        {
            string[] suggestion = new string[0];
            foreach (string s in dictionary.Where(s => s.Contains(stub.ToLower())))
            {
                Array.Resize(ref suggestion, suggestion.Length + 1);
                int newItem = suggestion.GetUpperBound(0);
                suggestion[newItem] = s;
            }

            return suggestion;
        }
    }
}
