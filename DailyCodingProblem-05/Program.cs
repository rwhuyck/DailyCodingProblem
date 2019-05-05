using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_05
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * This problem was asked by Jane Street.

                cons(a, b) constructs a pair, and car(pair) and cdr(pair) 
                returns the first and last element of that pair. For example, 
                car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.

                Given this implementation of cons:

                def cons(a, b):
                    def pair(f):
                        return f(a, b)
                    return pair

                Implement car and cdr.
                */
            int a = 35;
            int b = 12;

            Console.WriteLine(Car(Cons(a, b)));
            Console.WriteLine(Cdr(Cons(a, b)));
            Console.ReadLine();

        }

        //Cons function as defined in the problem: makes the tuple value structure
        private static Tuple<int, int> Cons(int a, int b)
        {
            return Tuple.Create(a, b);
        }

        private static int Car(Tuple<int, int> pair)
        {
            return pair.Item1;
        }

        private static int Cdr(Tuple<int, int> pair)
        {
            return pair.Item2;
        }
    }
}
