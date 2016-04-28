using System;
using System.Collections.Generic;
using System.Drawing;

class MostPointsInAngle_v2
{
    static void Main()
    {
        List<Point> points = new List<Point>();
        List<double> pointsAngles = new List<double>();
        List<Point> resultPoints = new List<Point>();
        double result = 0;
        int resultPointsCount = 0;
        Console.Write("Enter n /points count/ = ");
        int n = int.Parse(Console.ReadLine());
        bool rndPoints = false;
        Random rnd = new Random();
        Console.Write("Random points? Y/N: ");
        string input = Console.ReadLine();

        if (input == "Y" || input == "y")
        {
            rndPoints = true;
        }

        for (int i = 0; i < n; i++)
        {

            if (rndPoints)
            {
                points.Add(new Point { X = rnd.Next(-10, 11), Y = rnd.Next(-10, 11) });
            }

            else
            {
                Console.Write("Enter X = ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter Y = ");
                int y = int.Parse(Console.ReadLine());
                points.Add(new Point { X = x, Y = y });
            }

            double pointAngle = (Math.Atan2(points[i].Y, points[i].X)) * (180 / Math.PI); //Изчисляваме ъгълът на всяка точка.
            if (pointAngle < 0)
            {
                pointAngle = 180 + (pointAngle + 180); // Преобразувам отрицателните ъгли за по - лесно пресмятане (0 - 360).
            }
            pointsAngles.Add(pointAngle);
            Console.WriteLine("Point {0} ({1},{2}) with angle = {3}", i + 1, points[i].X, points[i].Y, pointsAngles[i]);
        }

        Console.Write("Enter angle Alfa = ");
        double angle = double.Parse(Console.ReadLine());

        for (int i = 0; i < 360; i++)
        {
            int currentCount = 0;
            double firstArm = i;
            double secondArm = i + angle;
            for (int j = 0; j < pointsAngles.Count; j++)
            {
                if (secondArm > 360 && (pointsAngles[j] + 360) < secondArm && (pointsAngles[j] + 360) > firstArm)
                {
                    currentCount++;
                }
                if (pointsAngles[j] > firstArm && pointsAngles[j] < secondArm)
                {
                    currentCount++;
                }
            }
            
            if (currentCount > resultPointsCount)
            {
                result = i;
                resultPointsCount = currentCount;
            }
            
        }

        Console.WriteLine("Beta = " + result);
        Console.WriteLine("Points within angle Alfa: " + resultPointsCount);
    }
}