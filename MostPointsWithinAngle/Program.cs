using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MostPointsWithinAngle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static List<Point> PointsList(int n)
        {
            List<Point> points = new List<Point>();
            Console.WriteLine("Random points? Y/N: ");
            string ans = Console.ReadLine();
            bool rndPoints = false;
            Random rnd = new Random();

            if (ans == "Y" || ans == "y")
            {
                rndPoints = true;
            }

            for (int i = 0; i < n; i++)
            {

                if (rndPoints)
                {
                    points.Add(new Point { X = rnd.Next(-100, 101), Y = rnd.Next(-100, 101) });
                }

                else
                {
                    Console.Write("X = ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Y = ");
                    int y = int.Parse(Console.ReadLine());
                    points.Add(new Point { X = x, Y = y });
                }

                Console.WriteLine();
                Console.WriteLine("Point added: ({0},{1})", points[i].X, points[i].Y);
                Console.WriteLine();
            }

            return points;
        }
        private static List<double> CalculatePointsAngles(List<Point> points)
        {
            List<double> pointsAngles = new List<double>();
            foreach (Point point in points)
            {
                double angle = Math.Atan2(point.Y, point.X) * (180 / Math.PI);

                if (angle < 0)
                {
                    angle = 360 + angle;
                }

                pointsAngles.Add(angle);
            }

            pointsAngles.Sort();
            return pointsAngles;
        }
        private static double CalculateBeta(List<double> pointsAngles, double alfa)
        {
            double result = 0;
            int resultPointsCount = 0;
            int looped = 0;

            for (int i = 0; i < pointsAngles.Count; i++)
            {
                int currentPointsCount = 0;
                double firstArm = pointsAngles[i];
                double secondArm = firstArm + alfa;

                for (int j = i; j < pointsAngles.Count; j++)
                {
                    looped++;

                    if (pointsAngles[j] >= firstArm && pointsAngles[j] <= secondArm)
                    {
                        currentPointsCount++;
                    }

                    if (secondArm > 360 && pointsAngles[j] + 360 <= secondArm && pointsAngles[j] + 360 >= firstArm)
                    {
                        currentPointsCount++;
                    }

                    else
                    {
                        continue;
                    }
                }

                if (currentPointsCount > resultPointsCount)
                {
                    result = pointsAngles[i];
                    resultPointsCount = currentPointsCount;
                }
            }
            Console.WriteLine("Looped = " + looped);
            Console.WriteLine("{0} points within Alfa for", resultPointsCount);
            return result;
        }
    }
}
