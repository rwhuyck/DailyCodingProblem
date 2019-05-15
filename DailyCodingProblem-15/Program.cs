using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_15
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Facebook.

            Given a stream of elements too large to store in memory, 
            pick a random element from the stream with uniform probability.
            */

            //Let's simulate a small memory size by using a queue with size 10.
            Queue<char> fakeRAM = new Queue<char>(10);

            //Let's make a stream via passing characters into the queue from
            //a long string.
            string input = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder();
            Random rng = new Random();

            foreach (char letter in input)
            {
                if (fakeRAM.Count < 10)
                {
                    fakeRAM.Enqueue(letter);
                }
                else
                {
                    fakeRAM.Dequeue();
                    fakeRAM.Enqueue(letter);
                }

                //Start sampling at 9 to catch first value of the stream.
                if (fakeRAM.Count >= 9)
                {
                    //Let's sample the buffered stream randomly with a uniform probability,
                    //since Random.Next chooses values in a uniform distribution.
                    result.Append(fakeRAM.ElementAt(rng.Next(0, fakeRAM.Count)));
                }
            }

            //Read out results.
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
