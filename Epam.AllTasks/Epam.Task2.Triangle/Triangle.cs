using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Triangle
{
    public class Triangle
    {
        public Triangle()
        {
            this.A = 0;
            this.B = 0;
            this.C = 0;
        }

        public Triangle(double a, double b, double c) 
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides of triangle must be greater than 0");
            }

            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double A { get; private set; }

        public double B { get; private set; }

        public double C { get; private set; }
        
        public double Area
        {
            get
            {
                double p = (this.A + this.B + this.C) / 2;
                return Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
            }
        }
        
        public double Perimeter
        {
            get
            {
                return this.A + this.B + this.C;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine(
                "Side A: {0}{1}Side B: {2}{1}Side C: {3}{1}Square of triangle: {4}{1}Perimeter of triangle: {5}",
                this.A,
                Environment.NewLine,
                this.B,
                this.C,
                this.Area,
                this.Perimeter);
        }
    }
}
