using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_17
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Google.

            Suppose we represent our file system by a string in the following manner:

            The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:

            dir
                subdir1
                subdir2
                    file.ext

            The directory dir contains an empty sub-directory subdir1 and a 
            sub-directory subdir2 containing a file file.ext.

            The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" 
            represents:

            dir
                subdir1
                    file1.ext
                    subsubdir1
                subdir2
                    subsubdir2
                        file2.ext

            The directory dir contains two sub-directories subdir1 and subdir2. 
            subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. 
            subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.

            We are interested in finding the longest (number of characters) 
            absolute path to a file within our file system. For example, 
            in the second example above, the longest absolute path is 
            "dir/subdir2/subsubdir2/file2.ext", and its length is 32 
            (not including the double quotes).

            Given a string representing the file system in the above format, 
            return the length of the longest absolute path to a file in the abstracted file system. 
            If there is no file in the system, return 0.

            Note:

            The name of a file contains at least a period and an extension.

            The name of a directory or sub-directory will not contain a period.
            */

            string input = "dir\n\tsubdir1\n\t\tfile1.ext" +
                "\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";

            //Method should return: dir/subdir2/subsubdir2/file2.ext
            string result = FindLongestDir(input);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        //Returns formated longest directory string.
        static string FindLongestDir(string input)
        {
            List<string> substrings = new List<string>();
            int dirIndex = 0, fileIndex = 0;
            int depthIndex = 0, counter = 0;
            int offset = 1;
            string depthString = "";

            //Loops until deepest file is found.
            bool keepGoing = true;
            while (keepGoing)
            {
                depthString += "\t";
                depthIndex = input.IndexOf(depthString, depthIndex + offset);

                if (depthIndex == -1 || fileIndex == -1)
                {
                    keepGoing = false;
                }
                else
                {
                    fileIndex = input.IndexOf(".", depthIndex);

                    //Finds top level subdirectory above current file.
                    while (counter != fileIndex &&
                    counter < input.Length)
                    {
                        if (input.IndexOf("\n\t", counter)
                            != input.IndexOf("\n\t\t", counter))
                        {
                            dirIndex = input.IndexOf("\n\t", counter);
                        }

                        counter++;
                    }

                    //Adds filepath from top sublevel to file into a list.
                    substrings.Add(input.Substring(dirIndex, 
                        (fileIndex + 4) - dirIndex));
                }
            }

            //Finds the longest filepath.
            string fullDir = substrings.Aggregate("", 
                (max, curr) => max.Length > curr.Length ? max : curr);

            //Adds the top level directory name to complete full filepath
            string result = input.Substring(0, input.IndexOf("\n")) + fullDir;

            return result.Replace("\n", "/").Replace("\t", "");
        }
    }
}
