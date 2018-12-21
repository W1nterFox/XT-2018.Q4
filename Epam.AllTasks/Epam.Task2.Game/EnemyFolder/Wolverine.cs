using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.EnemyFolder
{
    public class Wolverine : Enemy
    {
        public Wolverine()
        {
            this.Location = new Point(0, 0);
        }

        public Wolverine(Point p1)
        {
            this.Location = p1;
        }

        public override int LoseHPCount { get; } = 45;

        public override void Bite(Player player)
        {
            Console.WriteLine("Wolverine bitten you furiously");
            player.LoseHP(this.LoseHPCount);
            Console.ReadKey();
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the wolverine");
        }

        public override void Roar()
        {
            Console.WriteLine("Wolverine say: pshshshshsh");
        }
    }
}
