using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_16
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Twitter.

            You run an e-commerce website and want to record 
            the last N order ids in a log. Implement a data structure 
            to accomplish this, with the following API:

                record(order_id): adds the order_id to the log
                get_last(i): gets the ith last element from the log. 
                i is guaranteed to be smaller than or equal to N.

            You should be as efficient with time and space as possible.
            */

            int orderN = 10;
            int logNumber = 1;

            Random rng = new Random();
            Queue<string> log = new Queue<string>(orderN);

            // Filling the "log" purely for this exercise.
            bool keepGoing = true;
            while (keepGoing)
            {
                log.Enqueue(rng.Next(10, 29).ToString() + 
                    "dst" + rng.Next(100, 799).ToString());

                if (log.Count >= orderN)
                {
                    keepGoing = false;
                }
            }

            string orderId = "15sad143";
            record(orderId, log, orderN);
            string result = getLast(logNumber, log);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        // Adds new element to the log, and removes oldest element.
        static void record(string orderId, Queue<string> log, int orderN)
        {
            if (log.Count >= orderN)
            {
                log.Dequeue();
                log.Enqueue(orderId);
            }
            else
            {
                log.Enqueue(orderId);
            }
        }

        // Returns the logNumber counting from the latest entry.
        static string getLast(int logNumber, Queue<string> log)
        {
            string result = log.ElementAt(log.Count - logNumber);
            return result;
        }
    }
}
