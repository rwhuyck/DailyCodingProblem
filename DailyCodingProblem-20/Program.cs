using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_20
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Google.

            Given two singly linked lists that intersect at some point, 
            find the intersecting node. The lists are non-cyclical.

            For example, given A = 3 -> 7 -> 8 -> 10 and 
            B = 99 -> 1 -> 8 -> 10, return the node with value 8.

            In this example, assume nodes with the same value 
            are the exact same node objects.

            Do this in O(M + N) time 
            (where M and N are the lengths of the lists) and constant space.
            */

            List A = new List(3, new List(7, new List(8 , new List(10, null))));
            List B = new List(99, new List(1, new List(8, new List(10, null))));

            int? result = FindIntersect(ref A, ref B);

            if (result is null)
            {
                Console.WriteLine("No Intersection found.");
            }
            else
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        static int? FindIntersect(ref List A, ref List B)
        {
            int? result = null;

            List.QSortInPlace(ref A);
            List.QSortInPlace(ref B);

            while (A != null && B != null)
            {
                if (A.Value == B.Value)
                {
                    result = A.Value;
                    return result;
                }
                else if (A.Value > B.Value)
                {
                    B = B.Next;
                }
                else if (A.Value < B.Value)
                {
                    A = A.Next;
                }
            }

            return result;
        }
    }

    class List
    {
        public int Value { get; set; }
        public List Next;

        //Helper functions and QuickSort from https://stackoverflow.com/a/768272
        public List()
        { }

        public List(int Value, List Next)
        {
            this.Value = Value;
            this.Next = Next;
        }

        //In place sorting keeps the space complexity constant
        public static void QSortInPlace(ref List xs)
        {
            if (xs == null) return;

            int pivot = xs.Value;
            List pivotNode = xs;
            xs = xs.Next;
            pivotNode.Next = null;
            // partition the list into two parts
            List smaller = null; // items smaller than pivot
            List larger = null; // items larger than pivot
            while (xs != null)
            {
                var rest = xs.Next;
                if (xs.Value < pivot)
                {
                    xs.Next = smaller;
                    smaller = xs;
                }
                else
                {
                    xs.Next = larger;
                    larger = xs;
                }
                xs = rest;
            }

            // sort the smaller and larger lists
            QSortInPlace(ref smaller);
            QSortInPlace(ref larger);

            // append smaller + [pivot] + larger
            AppendInPlace(ref pivotNode, larger);
            AppendInPlace(ref smaller, pivotNode);
            xs = smaller;
        }

        public static void AppendInPlace(ref List xs, List ys)
        {
            if (xs == null)
            {
                xs = ys;
                return;
            }

            // find the last node in xs
            List last = xs;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = ys;
        }

        public static string Show(List xs)
        {
            if (xs == null) return "";
            else return xs.Value.ToString() + " " + Show(xs.Next);
        }
    }
}
