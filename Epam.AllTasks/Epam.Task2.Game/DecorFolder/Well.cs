using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Game.DecorFolder;
using Epam.Task2.Round;

namespace Epam.Task2.Game.DecorFolder
{
    public class Well : DecorObject
    {
        public Well()
        {
            this.Location = new Point(0, 0);
        }

        public Well(Point p1)
        {
            this.Location = p1;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the well");
        }
    }
}
