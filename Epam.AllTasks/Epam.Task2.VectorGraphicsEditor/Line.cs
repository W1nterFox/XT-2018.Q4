using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Line : Figure
    {
        public Line(Point p1, Point p2)
        {
            this.Point1 = p1;
            this.Point2 = p2;
        }

        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public override void Draw()
        {
            Console.WriteLine("Drawn the line");
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Point 1: ({0},{1})", this.Point1.X, this.Point1.Y);
            Console.WriteLine("Point 2: ({0},{1})", this.Point2.X, this.Point2.Y);
        }

        public override string ToString()
        {
            return "Line";
        }
    }
}
