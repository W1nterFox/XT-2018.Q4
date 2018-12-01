using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1.Rectangle
{
    public class Rectangle
    {
        private int width;
        private int length;

        public Rectangle()
        {
        }

        public Rectangle(int width, int length)
        {
            if (width < 1 || length < 1)
            {
                throw new ArgumentOutOfRangeException("Sides of rectangle must be greater than 0");
            }

            this.width = width;
            this.length = length;
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides of rectangle must be greater than 0");
                }

                this.width = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides of rectangle must be greater than 0");
                }

                this.length = value;
            }
        }
        
        public int CalcSquare()
        {
            return this.width * this.length;
        }
    }
}
