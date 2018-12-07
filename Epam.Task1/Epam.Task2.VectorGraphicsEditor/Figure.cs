using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.VectorGraphicsEditor
{
    public abstract class Figure
    {
        public abstract void Draw();

        public abstract void PrintInfo();

        public abstract override string ToString();
    }
}
