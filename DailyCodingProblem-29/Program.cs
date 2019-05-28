using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_29
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Amazon.

            Run-length encoding is a fast and simple method of encoding strings. 
            The basic idea is to represent repeated successive characters as a 
            single count and character. For example, the string "AAAABBBCCDAA" 
            would be encoded as "4A3B2C1D2A".

            Implement run-length encoding and decoding. You can assume the 
            string to be encoded have no digits and consists solely of alphabetic 
            characters. You can assume the string to be decoded is valid. 
            */

            string input = "AAAABBBCCDAA";
            string encoded = Encode(input);

            Console.WriteLine(encoded);
            Console.WriteLine(Decode(encoded));

            Console.ReadLine();
        }

        static string Encode(string input)
        {
            string encoded = "";
            int counter = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length)
                {
                    if (input[i] == input[i + 1])
                    {
                        counter++;
                    }
                    else
                    {
                        encoded += counter.ToString() + input[i];
                        counter = 1;
                    }
                }
                else
                {
                    encoded += counter.ToString() + input[i];
                    counter = 1;
                }   
            }

            return encoded;
        }

        static string Decode(string input)
        {
            string decoded = "";
            string number = "";
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    number += input[i];
                }
                else if (int.TryParse(number, out counter))
                {
                    while (counter > 0)
                    {
                        decoded += input[i];
                        counter--;
                    }
                    number = "";
                }
                else
                {
                    decoded += input[i];
                }
            }

            return decoded;
        }
    }
}
