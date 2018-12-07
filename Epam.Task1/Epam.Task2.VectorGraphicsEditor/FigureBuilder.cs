using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class FigureBuilder
    {
        public Line CreateLine()
        {
            Console.WriteLine("Enter coordinates of first point: ");
            Point pointFirst = this.CreatePoint();
            Console.WriteLine("Enter coordinates of second point: ");
            Point pointSecond = this.CreatePoint();
            return new Line(pointFirst, pointSecond);
        }

        public Circle CreateCircle()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = this.CreatePoint();

            Console.WriteLine("Enter radius: ");
            Console.Write("Radius: ");
            int r;
            while (!int.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter radius again: ");
            }

            return new Circle(pointCenter, r);
        }

        public Round CreateRound()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = this.CreatePoint();

            Console.WriteLine("Enter radius: ");
            int r;
            while (!int.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter radius again: ");
            }

            return new Round(pointCenter, r);
        }

        public Ring CreateRing()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = this.CreatePoint();

            Console.WriteLine("Enter inner radius: ");
            int innerR;
            while (!int.TryParse(Console.ReadLine(), out innerR))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter inner radius again: ");
            }

            Console.WriteLine("Enter outer radius: ");
            int outerR;
            while (!int.TryParse(Console.ReadLine(), out outerR))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter outer radius again: ");
            }

            return new Ring(innerR, outerR, pointCenter);
        }

        public Rectangle CreateRectangle()
        {
            Console.WriteLine("Enter coordinates of first point: ");
            Point pointFirst = this.CreatePoint();
            Console.WriteLine("Enter coordinates of second point: ");
            Point pointSecond = this.CreatePoint();
            return new Rectangle(pointFirst, pointSecond);
        }

        public Point CreatePoint()
        {
            Console.Write("X: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Incorrect value: Coordinate X must be number");
                Console.WriteLine("Enter X again: ");
            }

            Console.Write("Y: ");
            int y;
            while (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Incorrect value: Coordinate Y must be number");
                Console.WriteLine("Enter Y again: ");
            }

            Console.WriteLine();
            return new Point(x, y);
        }
    }
}
