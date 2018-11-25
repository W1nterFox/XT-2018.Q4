using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1.Rectangle
{
    class Rectangle
    {
        Int32 _aSide;
        Int32 _bSide;
        Int32 _square;

        public Int32 aSide
        {
            get { return _aSide; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides of rectangle must be greater than 0");
                }
                _aSide = value;
            }
        }
        public Int32 bSide
        {
            get { return _bSide; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides of rectangle must be greater than 0");
                }
                _bSide = value;
            }
        }

        public Rectangle(){}

        public Rectangle(Int32 aSide, Int32 bSide)
        {
            if (aSide < 1 || bSide < 1)
            {
                throw new ArgumentOutOfRangeException("Sides of rectangle must be greater than 0");
            }
            this._aSide = aSide;
            this._bSide = bSide;
        }

        public Int32 CalcSquare()
        {
            return _aSide * _bSide;
        }

    }
}
