using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Circle : Figure
    {
        public Circle()
        {
            this.Radius = 0;
            this.PointCenter = new Point(0, 0);
        }

        public Circle(Point p, int radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be greater than 0");
            }

            this.Radius = radius;
            this.PointCenter = p;
        }

        public Point PointCenter { get; protected set; }

        public int Radius { get; protected set; }

        public override void Draw()
        {
            Console.WriteLine("Drawn the circle");
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Central point: ({0},{1})", this.PointCenter.X, this.PointCenter.Y);
            Console.WriteLine("Radius: {0}", this.Radius);
        }
    }
}
