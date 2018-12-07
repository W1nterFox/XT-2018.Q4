using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Round : Circle
    {
        public Round()
        {
            this.Radius = 0;
            this.PointCenter = new Point(0, 0);
        }

        public Round(Point point, int radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be greater than 0");
            }

            this.Radius = radius;
            this.PointCenter = point;
        }
        
        public double Length => 2 * Math.PI * this.Radius;

        public double Area => Math.PI * this.Radius * this.Radius;

        public override void PrintInfo()
        {
            Console.WriteLine("Central point: ({0},{1})", this.PointCenter.X, this.PointCenter.Y);
            Console.WriteLine("Area: {0}", this.Area);
            Console.WriteLine("Length: {0}", this.Length);
            Console.WriteLine("Radius: {0}", this.Radius);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the round");
        }

        public override string ToString()
        {
            return "Round";
        }
    }
}
