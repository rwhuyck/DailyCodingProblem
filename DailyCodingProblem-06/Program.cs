using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DailyCodingChallenge_06
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This problem was asked by Google.

                An XOR linked list is a more memory efficient doubly linked list. 
                Instead of each node holding next and prev fields, it holds a 
                field named both, which is an XOR of the next node 
                and the previous node. Implement an XOR linked list; it has an 
                add(element) which adds the element to the end, and a get(index) 
                which returns the node at index.

                If using a language that has no pointers (such as Python), 
                you can assume you have access to get_pointer and dereference_pointer 
                functions that converts between nodes and memory addresses.
             */

            //This is actually a really bad idea to do in mordern times,
            //and C# will do its best to prevent this from being done, though it IS possible. 
            //Unsafe and no real gain to storage efficiency that matters anymore.
            //Also incompatable with ANY managed object since it is unsafe code,
            //making it even less useful! And has to be specialy compiled with /unsafe.

            //A full conceptual solution comes from https://stackoverflow.com/a/5992763
            //And the code can be found here: https://gist.github.com/chklauser/cb140308780fa05bc434

            //DO NOT TRY TO COMPILE OR RUN ANY SUCH CODE!

            //My pseudocode below, just for fun.
            int a;
            int b;
            int c;
            int index;
            int* pntrA = &a;
            int* pntrB = &b;
            int* pntrC = &c;
            int*[] xorList = new int*[0];
            _add(pntrA, pntrB, xorList);

            Console.WriteLine(GetNode(xorList, index));
            Console.ReadLine();
        }
        static unsafe void _add(int* pntr1, int* pntr2, int*[] xorList)
        {
            int* node = pntr1 ^ pntr2;
            Array.Resize(ref xorList, xorList.Length + 1);
            int add = xorList.GetUpperBound(0);
            xorList[add] = node;
        }

        static unsafe int* GetNode(int*[] xorList, int index)
        {
            if (index < xorList.Length)
            {
                return xorList[index];
            }     
        }
    }
}
