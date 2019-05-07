using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_08
{
    class Program
    {
        static void Main(string[] args)
        {
            /*This problem was asked by Google.

            A unival tree (which stands for "universal value") is a tree 
            where all nodes under it have the same value.

            Given the root to a binary tree, count the number of unival subtrees.

            For example, the following tree has 5 unival subtrees:

               0
              / \
             1   0
                / \
               1   0
              / \
             1   1
            */

            Node tree = new Node();
            tree.left = new Node();
            tree.right = new Node();
            tree.right.right = new Node();
            tree.right.left = new Node();
            tree.right.left.left = new Node();
            tree.right.left.right = new Node();
            tree.left.value = 1;
            tree.right.value = 0;
            tree.right.right.value = 0;
            tree.right.left.value = 1;
            tree.right.left.left.value = 1;
            tree.right.left.right.value = 1;

            int numberUnival = Count(tree); //Returns 5
            Console.WriteLine(numberUnival);
            Console.ReadLine();
        }

        private static bool IsUnival(Node tree)
        {
            if (tree is null)
            {
                return true;
            }
            else if (tree.left != null && tree.left.value != tree.value)
            {
                return false;
            }
            else if (tree.right != null && tree.right.value != tree.value)
            {
                return false;
            }
            else if (IsUnival(tree.left) && IsUnival(tree.right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int Count(Node tree)
        {
            int count = 0;
            if (tree is null)
            {
                return count;
            }
            if (IsUnival(tree))
            {
                count = Count(tree.left) + Count(tree.right) + 1;
            }
            else
            {
                count = Count(tree.left) + Count(tree.right);
            }
            return count;
        }
    }
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }
}
