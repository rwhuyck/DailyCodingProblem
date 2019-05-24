using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_24
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Google.

            Implement locking in a binary tree. A binary tree node can be 
            locked or unlocked only if all of its descendants or ancestors are not locked.

            Design a binary tree node class with the following methods:

                is_locked, which returns whether the node is locked
                lock, which attempts to lock the node. If it cannot be locked, 
                then it should return false. Otherwise, it should lock it and return true.
                unlock, which unlocks the node. If it cannot be unlocked, 
                then it should return false. Otherwise, it should unlock it and return true.

            You may augment the node to add parent pointers or any other property 
            you would like. You may assume the class is used in a single-threaded program, 
            so there is no need for actual locks or mutexes. Each method should run in O(h), 
            where h is the height of the tree.
            */

            Node tree = new Node();
            tree.parent = null;
            tree.left = new Node();
            tree.left.parent = tree;
            tree.right = new Node();
            tree.right.parent = tree;
            tree.right.right = new Node();
            tree.right.right.parent = tree.right;
            tree.right.left = new Node();
            tree.right.left.parent = tree.right;
            tree.right.left.left = new Node();
            tree.right.left.left.parent = tree.right.left;
            tree.right.left.right = new Node();
            tree.right.left.right.parent = tree.right.left;
            tree.left.isLocked = false;
            tree.right.isLocked = true;
            tree.right.right.isLocked = false;
            tree.right.left.isLocked = false;
            tree.right.left.left.isLocked = true;
            tree.right.left.right.isLocked = false;

            // Should be false
            bool locked = Node.Lock(tree.right.left);
            Console.WriteLine(locked);

            // Should be true
            bool unlocked = Node.Unlock(tree.right.left.left);
            Console.WriteLine(unlocked);

            // Should now be true
            locked = Node.Lock(tree.right.left);
            Console.WriteLine(locked); 

            Console.ReadLine();
        }
    }

    class Node
    {
        public bool isLocked;
        public Node left;
        public Node right;
        public Node parent;

        public static bool Lock(Node tree)
        {
            bool locked = false;

            if (!ParentLocked(tree) || !ChildLocked(tree))
            {
                tree.isLocked = true;
                locked = true;
            }

            return locked;
        }

        public static bool Unlock(Node tree)
        {
            bool unlocked = false;

            if (!tree.isLocked)
            {
                unlocked = true;
            }
            else if (!ParentLocked(tree) || !ChildLocked(tree))
            {
                tree.isLocked = false;
                unlocked = true;
            }

            return unlocked;
        }

        public static bool ParentLocked(Node tree)
        {
            bool locked = false;
            
            while (tree.parent != null)
            {
                if (tree.parent.isLocked)
                {
                    locked = true;
                }

                tree.parent = tree.parent.parent;
            }

            return locked;
        }

        public static bool ChildLocked(Node tree)
        {
            bool locked = false;

            if (tree != null)
            {
                if (tree.isLocked)
                {
                    locked = true;
                }
                if (ChildLocked(tree.left))
                {
                    locked = true;
                }
                if (ChildLocked(tree.right))
                {
                    locked = true;
                }
            }

            return locked;
        }

        /*
        Enumeration exmple with Linq from https://stackoverflow.com/a/27442318
        Keeping these here as code examples for the future


        public IEnumerator<bool> GetEnumerator()
        {
            var leftEnumerable = (IEnumerable<bool>)left ?? new bool[0];
            var rightEnumerable = (IEnumerable<bool>)right ?? new bool[0];

            return leftEnumerable.Concat(new bool[] { isLocked })
                                 .Concat(rightEnumerable)
                                 .GetEnumerator();
        }

        Alternate method


        public IEnumerator<bool> GetEnumerator()
        {
            if (left != null)
            {
                foreach (var v in left)
                {
                    yield return v;
                }
            }

            yield return isLocked;

            if (right != null)
            {
                foreach (var v in right)
                {
                    yield return v;
                }
            }
        }
        */
    }
}
