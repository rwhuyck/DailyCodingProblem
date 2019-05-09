using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              This problem was asked by Apple.

              Implement a job scheduler which takes in a 
              function f and an integer n, and calls f after n milliseconds. 
             */

            int n = 3000;
            Scheduler(() => HelloWorld(), n);
            Console.ReadLine();
        }

        static async void Scheduler(Func<string> HelloWorld, int n)
        {
            await Task.Delay(n);
            Console.WriteLine(HelloWorld());
        }

        static string HelloWorld()
        {
            return "Hello, World!";
        }
    }
}
