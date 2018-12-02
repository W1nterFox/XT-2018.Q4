using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.BonusFolder
{
    public class Cherry : Bonus
    {
        public Cherry()
        {
            this.Location = new Point(0, 0);
        }

        public Cherry(Point p1)
        {
            this.Location = p1;
        }

        public override int HealHPCount { get; } = 15;

        public override void Draw()
        {
            Console.WriteLine("Drawn the Cherry");
        }
    }
}
