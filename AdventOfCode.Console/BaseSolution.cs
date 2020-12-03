﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Console
{
    public abstract class BaseSolution : ISolution
    {
        public override string ToString()
        {
            return $"{GetType().Name}:{Environment.NewLine}" +
                   $"\tSilver Star: {SilverStar()}{Environment.NewLine}" +
                   $"\tGold Star: {GoldStar()}{Environment.NewLine}{Environment.NewLine}";
        }

        public abstract string SilverStar();

        public abstract string GoldStar();
    }
}
