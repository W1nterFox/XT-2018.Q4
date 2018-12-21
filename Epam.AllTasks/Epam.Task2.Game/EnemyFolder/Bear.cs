using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.EnemyFolder
{
    public class Bear : Enemy
    {
        public Bear()
        {
            this.Location = new Point(0, 0);
        }

        public Bear(Point p1)
        {
            this.Location = p1;
        }

        public override int LoseHPCount { get; } = 85;

        public override void Bite(Player player)
        {
            Console.WriteLine("The bear hit you with his big paw");
            player.LoseHP(this.LoseHPCount);
            Console.ReadKey();
        }

        public override void Draw()
        {
            Console.WriteLine("Drawn the bear");
        }

        public override void Roar()
        {
            Console.WriteLine("Bear say: Argrhgrhg");
        }
    }
}
