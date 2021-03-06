﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game.BonusFolder
{
    public class Mushroom : Bonus
    {
        public Mushroom()
        {
            this.Location = new Point(0, 0);
        }

        public Mushroom(Point p1)
        {
            this.Location = p1;
        }

        public override int HealHPCount { get; } = 35;

        public override void Draw()
        {
            Console.WriteLine("Drawn the Mushroom");
        }
    }
}
