using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Library
{
    public abstract class BaseSolution : ISolution
    {
        private const string DATA_FILE = "data.txt";
        
        internal string ReadAllText(Type t) =>
            File.ReadAllText(Path.Combine($"{t.Name}", DATA_FILE));
        
        internal IEnumerable<string> ReadLines(Type t) =>
            File.ReadLines(Path.Combine($"{t.Name}", DATA_FILE));
        
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
