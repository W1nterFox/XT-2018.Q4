using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Ring
{
    class Ring
    {
        private Round.Round innerRound;
        private Round.Round outerRound;

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
            innerRound = new Round.Round(new Round.Point(0, 0), innerR);
            outerRound = new Round.Round(new Round.Point(0, 0), outerR);
        }

        public Ring(int innerR, int outerR, Round.Point point)
        {
            if (innerR >= outerR)
            {
                throw new ArgumentException("Outer radius must be greater than inner radius");
            }
            if (innerR <= 0 || outerR <= 0)
            {
                throw new ArgumentException("Outer radius and inner radius must be positive ");
            }
            innerRound = new Round.Round(new Round.Point(point.X, point.Y), innerR);
            outerRound = new Round.Round(new Round.Point(point.X, point.Y), outerR);
        }

        public double Area => outerRound.Area - innerRound.Area;

        public double Length => outerRound.Length + innerRound.Length;

        public int InnerRadius => this.innerRound.Radius;
        
        public int OuterRadius => this.outerRound.Radius;

        public int X => this.innerRound.PointCenter.X;

        public int Y => this.outerRound.PointCenter.Y;
    }
}
