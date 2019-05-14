using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem_14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            This problem was asked by Google.

            The area of a circle is defined as πr^2. 
            Estimate π to 3 decimal places using a Monte Carlo method.

            Hint: The basic equation of a circle is x2 + y2 = r2.
            */

            //Method based on this one made in Java:
            //http://cronodon.com/Programming/MonteCarlo_1.html
            Random random = new Random();
            double randX;
            double randY;
            bool inCircle;
            int hits = 0;
            int misses = 0;
            double radius = 1.0;
            double areaCircle = Math.PI * radius * radius;
            double areaSquare = (2 * radius) * (2 * radius);
            double estimateArea = 0;
            double estimatedPi = 0;
            double tolerance = 1e-5;

            while (Math.Abs(Math.PI - estimatedPi) > tolerance)
            {
                randX = (random.NextDouble() - 0.5) * 2;
                randY = (random.NextDouble() - 0.5) * 2;
                inCircle = MonteCarlo(randX, randY, radius);

                if (inCircle)
                {
                    hits++;
                }
                else
                {
                    misses++;
                }

                double areaRatio = (double)hits / (misses + hits);
                estimateArea = areaRatio * areaSquare;
                estimatedPi = estimateArea / (radius * radius);
            }

            double diffArea = Math.Abs(estimateArea - areaCircle);

            Console.WriteLine("Pi estimated as: " + estimatedPi.ToString());
            Console.WriteLine("Difference between estimated circle area" +
                " and exact area: " + diffArea.ToString());
            Console.ReadLine();
        }

        static bool MonteCarlo(double x, double y, double radius)
        {
            bool hit = false;
            double guess = Math.Pow((Math.Pow(x, 2) + Math.Pow(y, 2)), 0.5);

            if (guess <= radius)
            {
                hit = true;
            }

            return hit;
        }
    }
}
