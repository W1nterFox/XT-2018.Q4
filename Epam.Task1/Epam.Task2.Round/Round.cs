using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Round
{
    public class Round
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

        public Point PointCenter { get; private set; }

        public int Radius { get; private set; }

        public double Length => 2 * Math.PI * this.Radius;

        public double Area => Math.PI * this.Radius * this.Radius;
        
        public void PrintInfo()
        {
            Console.WriteLine(
                "Coordinate X: {0}{1}Coordinate Y: {2}{1}Square of round: {3}{1}Length of round: {4}",
                this.PointCenter.X, 
                Environment.NewLine, 
                this.PointCenter.Y, 
                this.Area, 
                this.Length);
        }
    }
}
