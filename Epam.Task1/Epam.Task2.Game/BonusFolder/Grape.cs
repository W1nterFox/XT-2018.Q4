using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.BonusFolder
{
    public class Grape : Bonus
    {
        public Grape()
        {
            this.Location = new Point(0, 0);
        }

        public Grape(Point p1)
        {
            this.Location = p1;
        }

        public override int HealHPCount { get; } = 50;

        public override void Draw()
        {
            Console.WriteLine("Drawn the Grape");
        }
    }
}
