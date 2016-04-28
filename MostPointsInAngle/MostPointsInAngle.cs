using System;
using System.Collections.Generic;
using System.Drawing;

class MostPointsInAngle_v2
{
    static double result = 0;
    static int resultPointsCount = 0;

    static void Main()

    {

        List<Point> points = new List<Point>();
        List<double> pointsAngles = new List<double>();
        Console.Write("--> n /points count/ = ");
        int n = int.Parse(Console.ReadLine());
        bool rndPoints = false;
        Random rnd = new Random();
        Console.Write("--> Random points? Y/N: ");
        string input = Console.ReadLine();

        if (input == "Y" || input == "y")
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
                Console.Write("--> X = ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("--> Y = ");
                int y = int.Parse(Console.ReadLine());
                points.Add(new Point { X = x, Y = y });
            }

            double pointAngle = (Math.Atan2(points[i].Y, points[i].X)) * (180 / Math.PI); // Изчисляваме ъгълът на всяка точка.

            if (pointAngle < 0)
            {
                pointAngle = 180 + (pointAngle + 180); // Преобразувам отрицателните ъгли за по - лесно пресмятане (0 - 360).
            }

            pointsAngles.Add(pointAngle);
            Console.WriteLine();
            Console.WriteLine("Point {0} ({1},{2}) with angle = {3}", i + 1, points[i].X, points[i].Y, pointsAngles[i]);
            Console.WriteLine();

        }

        Console.Write("--> Alfa = ");
        double angle = double.Parse(Console.ReadLine());
        CalculateBeta(pointsAngles, angle);
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Beta = "+result);
        Console.WriteLine("Total points within Alfa = "+resultPointsCount);
        Console.WriteLine("---------------------------------");
    }

    private static void CalculateBeta(List<double> pointsAngles, double angle)

    {
        pointsAngles.Sort();
        for (int i = 0; i < pointsAngles.Count; i++)
        {
            int currentCount = 0;
            double firstArm = pointsAngles[i];
            double secondArm = firstArm + angle;
            for (int j = 0; j < pointsAngles.Count; j++)
            {

                if (pointsAngles[j] >= firstArm && pointsAngles[j] <= secondArm)
                {
                    currentCount++;
                }

                if (secondArm > 360 && (pointsAngles[j] + 360) <= secondArm && (pointsAngles[j] + 360) >= firstArm)
                {
                    currentCount++;
                }
            }

            if (currentCount > resultPointsCount)
            {
                result = firstArm;
                resultPointsCount = currentCount;
            }
        }
    }
}