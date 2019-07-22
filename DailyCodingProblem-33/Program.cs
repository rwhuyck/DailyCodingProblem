using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_33
{
    class Program
    {
        static void Main()
        {
            /*
            This problem was asked by Microsoft.

            Compute the running median of a sequence of numbers. 
            That is, given a stream of numbers, print out the median of the list 
            so far on each new element.

            Recall that the median of an even-numbered list is the average 
            of the two middle numbers.

            For example, given the sequence [2, 1, 5, 7, 2, 0, 5], 
            your algorithm should print out:

            2
            1.5
            2
            3.5
            2
            2
            2
            */

            int[] input = { 2, 1, 5, 7, 2, 0, 5 };
            Median thisMedian = new Median();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(thisMedian.FindMedian(input[i]));
            }

            Console.ReadLine();
        }
    }

    class Median
    {
        private int[] buffer { get; set; }

        public float FindMedian(int input)
        {
            float result;
            int index;

            // Initialize the buffer on first pass
            if (this.buffer is null)
            {
                int[] initialize = { input };
                this.buffer = initialize;
                result = input;
            }
            else
            {
                int[] buffer = this.buffer;
                int end = buffer.Length - 1;
                index = binarySearch(buffer, input, 0, end);

                Array.Resize(ref buffer, buffer.Length + 1);

                // Shift array to right, and insert new input
                // value into proper index, to sort ascending
                for (int i = buffer.Length - 1; i > index; i--)
                {
                    buffer[i] = buffer[i - 1];
                }
                buffer[index] = input;

                // Find the median: center number if odd length,
                // average of two center numbers if even length
                if (buffer.Length % 2 != 0)
                {
                    result = buffer[end / 2 + 1];
                }
                else
                {
                    result = ((float)buffer[end / 2] +
                        (float)buffer[end / 2 + 1]) / 2;
                }

                // Save the buffer as an object property for subsequent rounds
                this.buffer = buffer;
            }

            return result;
        }

        // Find the proper index to insert the new input value into
        static int binarySearch(int[] buffer, int input, int start, int end)
        {
            int index;

            // Termination condition to assign the input its
            // proper array index in ascending order
            if (start == end)
            {
                if (input >= buffer[start])
                {
                    index = start + 1;
                }
                else if (start != 0)
                {
                    index = start - 1;
                }
                else
                {
                    index = 0;
                }
            }
            else
            {
                // Check which half of array input should belong to
                // and search that half of the array recursively
                if (input > buffer[(start + end) / 2])
                {
                    start = (start + end) / 2 + 1;
                    index = binarySearch(buffer, input, start, end);
                }
                else
                {
                    end = (start + end) / 2;
                    index = binarySearch(buffer, input, start, end);
                }
            }

            return index;
        }
    }
}
