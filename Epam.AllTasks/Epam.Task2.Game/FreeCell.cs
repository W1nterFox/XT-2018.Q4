using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game
{
    public class FreeCell : GameObject
    {
        public FreeCell()
        {
            this.Location = new Point(0, 0);
        }

        public FreeCell(Point p1)
        {
            this.Location = p1;
        }

        public override void Draw()
        {
            Console.WriteLine("It is free cell");
        }
    }
}
