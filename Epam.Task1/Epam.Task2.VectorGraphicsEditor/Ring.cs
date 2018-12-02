using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Ring : Figure
    {
        private Round innerRound;
        private Round outerRound;

        public Ring(int innerR, int outerR)
        {
            if (innerR >= outerR)
            {
                throw new ArgumentException("Outer radius must be greater than inner radius");
            }

            if (innerR <= 0 || outerR <= 0)
            {
                throw new ArgumentException("Outer radius and inner radius must be positive ");
            }

            this.innerRound = new Round(new Point(0, 0), innerR);
            this.outerRound = new Round(new Point(0, 0), outerR);
        }

        public Ring(int innerR, int outerR, Point point)
        {
            if (innerR >= outerR)
            {
                throw new ArgumentException("Outer radius must be greater than inner radius");
            }

            if (innerR <= 0 || outerR <= 0)
            {
                throw new ArgumentException("Outer radius and inner radius must be positive ");
            }

            this.innerRound = new Round(new Point(point.X, point.Y), innerR);
            this.outerRound = new Round(new Point(point.X, point.Y), outerR);
        }

        public double Area => this.outerRound.Area - this.innerRound.Area;

        public double Length => this.outerRound.Length + this.innerRound.Length;

        public int InnerRadius => this.innerRound.Radius;

        public int OuterRadius => this.outerRound.Radius;

        public int X => this.innerRound.PointCenter.X;

        public int Y => this.outerRound.PointCenter.Y;

        public override void Draw()
        {
            Console.WriteLine("Drawn the ring");
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Central point: ({0},{1})", this.X, this.Y);
            Console.WriteLine("Area: {0}", this.Area);
            Console.WriteLine("Length: {0}", this.Length);
            Console.WriteLine("Outer radius: {0}", this.OuterRadius);
            Console.WriteLine("Inner radius: {0}", this.InnerRadius);
        }
    }
}
