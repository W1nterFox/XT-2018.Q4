using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.EnemyFolder
{
    public class Wolf : Enemy
    {
        public Wolf()
        {
            this.Location = new Point(0, 0);
        }

        public Wolf(Point p1)
        {
            this.Location = p1;
        }

        public override int LoseHPCount { get; } = 65;

        public override void Bite(Player player)
        {
            Console.WriteLine("The wolf has bit you in the flank");
            player.LoseHP(this.LoseHPCount);
            Console.ReadKey();
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the wolf");
        }

        public override void Roar()
        {
            Console.WriteLine("Wolf say: Gav-gav");
        }
    }
}
