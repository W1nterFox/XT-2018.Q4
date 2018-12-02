using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        public Rectangle(Point p1, Point p2)
        {
            this.PointTopLeft = p1;
            this.PointBottomRight = p2;
        }

        public double Area => (this.PointTopLeft.X - this.PointBottomRight.X) * (this.PointTopLeft.Y - this.PointBottomRight.Y);

        public Point PointTopLeft { get; set; }

        public Point PointBottomRight { get; set; }

        public override void Draw()
        {
            Console.WriteLine("Drawn the rectangle");
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Top left corner: ({0},{1})", this.PointTopLeft.X, this.PointTopLeft.Y);
            Console.WriteLine("Bottom right corner: ({0},{1})", this.PointBottomRight.X, this.PointBottomRight.Y);
            Console.WriteLine("Area: {0}", this.Area);
        }
    }
}
