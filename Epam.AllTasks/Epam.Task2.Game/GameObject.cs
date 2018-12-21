using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game
{
    public abstract class GameObject
    {
        public Point Location { get; internal set; }

        public abstract void Draw();
    }
}
