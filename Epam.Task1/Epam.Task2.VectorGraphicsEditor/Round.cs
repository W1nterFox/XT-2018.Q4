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
            Console.WriteLine(
                "Central point: ({0},{1}){2}Area of round: {3}{2}Length of round: {4}{2}Radius: {5}",
                this.PointCenter.X,
                this.PointCenter.Y,
                Environment.NewLine,
                this.Area,
                this.Length,
                this.Radius);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the round");
        }
    }
}
