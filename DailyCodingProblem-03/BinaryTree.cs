using System;
using System.Collections.Generic;
using System.Text;

namespace DailyCodingProblem_03
{
    //Takes in a sentence with breaks it down into a binary tree object with
    //each node being a word from the sentence.
    //Tree creation method based on code from https://stackoverflow.com/questions/828398/how-to-create-a-binary-tree
    class BinaryTree
    {
        internal string word;
        internal BinaryTree left;
        internal BinaryTree right;

        //Take string array from main program and inhert it along with index to new object.
        internal BinaryTree(string[] input) : this(input, 0)
        {}

        //Send object and string array with starting index to the deserilize method 
        //to make tree.
        //This method takes the tree object and parameters to construct the binary tree
        BinaryTree(string[] input, int index)
        {
            this.word = input[index];

            if ((index * 2 + 1) < input.Length)
            {
                this.left = new BinaryTree(input, index * 2 + 1);
            }

            if ((index * 2 + 2) < input.Length)
            {
                this.right = new BinaryTree(input, index * 2 + 2);
            }
        }

        //Breadth-first traversal using a queue to reconstruct sentence 
        //by serializing the tree.
        //Implimentation based on https://jamesmccaffrey.wordpress.com/2011/10/22/breadth-first-and-depth-first-traversal-of-a-c-binary-search-tree/
        internal string serialize()
        {
            string result = "";
            Queue<BinaryTree> queue = new Queue<BinaryTree>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                BinaryTree node = queue.Dequeue();
                result += node.word + " ";

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                    
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }     
            }

            return result;
        }

        //First try at rebuilding sentence (serialize) from tree.
        //Problem is it is pre-order traversal, which does not put the sentence in order.
        //In-order and post-order also do not work, so a non-classical recursive
        //method is needed. See above for method using queue and breadth-first traversal.
        //static internal string serialize(BinaryTree tree)
        //{
        //    string sentence = "";

        //    //Pre-order traversal
        //    if (tree != null)
        //    {
        //        sentence += tree.word + " ";

        //        if (tree.left != null)
        //        {
        //            sentence += serialize(tree.left);
        //        }

        //        if (tree.right != null)
        //        {
        //            sentence += serialize(tree.right);
        //        }
        //    }

        //    return sentence;
        //}
    }
}
