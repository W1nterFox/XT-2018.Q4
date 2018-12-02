using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Game
{
    public abstract class Enemy : MovableObject
    {
        public abstract int LoseHPCount { get; }

        public abstract void Roar();

        public abstract void Bite(Player player);
    }
}
