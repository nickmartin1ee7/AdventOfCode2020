using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Library.Day3
{
    public class Day3 : BaseSolution
    {
        private readonly IEnumerable<string> _rawData;

        public Day3()
        {
            _rawData = File.ReadLines(Path.Combine($"{GetType().Name}", "data.txt"));
        }
        
        public override string SilverStar()
        {
            var data = ProcessData(_rawData);

            var silverResult = SolveSilverStar(data);

            return $"{silverResult }";
        }

        public override string GoldStar()
        {
            var data = ProcessData(_rawData);

            var goldResult = SolveGoldStar(data);

            return $"{goldResult}";
        }

        private Map ProcessData(IEnumerable<string> rawData) =>
            new Map(rawData.ToArray());

        private string SolveSilverStar(Map data) =>
            $"{data.GetCollisions(3, 1)}";

        private string SolveGoldStar(Map data)
        {
            ulong result;
            result = (ulong)data.GetCollisions(1, 1);
            result *= (ulong)data.GetCollisions(3, 1);
            result *= (ulong)data.GetCollisions(5, 1);
            result *= (ulong)data.GetCollisions(7, 1);
            result *= (ulong)data.GetCollisions(1, 2);
            return $"{result}";
        }
    }

    #region Classes

    internal class Map
    {
        private string[] _instance { get; }

        internal Map(string[] rawMap)
        {
            _instance = rawMap;
        }

        internal int GetCollisions(int right, int down)
        {
            var collisions = 0;
            var xPos = 0;

            for (int yPos = _instance.Length - 1; yPos >= down; yPos -= down)
            {
                xPos += right;

                var maxLength = _instance[yPos].Length;

                if (xPos >= maxLength)
                    xPos -= maxLength;

                var geography = _instance[yPos][xPos];

                if (geography == '#')
                    collisions++;
            }

            return collisions;
        }
    }

    #endregion
}
