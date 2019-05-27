using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_26
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Google.

            Given a singly linked list and an integer k, 
            remove the kth last element from the list. 
            k is guaranteed to be smaller than the length of the list.

            The list is very long, so making more than one pass 
            is prohibitively expensive.

            Do this in constant space and in one pass. 
            */

            List A = new List(new List(new List(new List(new List(null)))));
            int k = 1;

            Console.WriteLine(A.CountList());
            A.DeleteElement(k);
            Console.WriteLine(A.CountList());
            Console.ReadLine();
        }
    }

    class List
    {
        public List Next;

        public List(List Next)
        {
            this.Next = Next;
        }

        public int CountList()
        {
            int count = 0;
            var node = this;

            while (node != null)
            {
                count++;
                node = node.Next;
            }
            
            return count;
        }

        public void DeleteElement(int k)
        {
            int nodeNumber = this.CountList() - k;
            int count = 0;
            List previousNode = null;
            var currentNode = this;

            while (count < nodeNumber && currentNode != null)
            {
                count++;
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            previousNode.Next = currentNode.Next;
        }
    }
}
