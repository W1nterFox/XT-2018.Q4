﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Game
{
    public abstract class Bonus : GameObject
    {
        public abstract int HealHPCount { get; }
    }
}
