﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Library.Day3
{
    public class Day3 : BaseSolution
    {
        private IEnumerable<string> _rawData;

        public Day3()
        {
            _rawData = ReadLines(GetType());
        }
        
        public override string SilverStar()
        {
            var data = ProcessData(_rawData);

            string silverResult = SolveSilverStar(data);

            return $"{silverResult }";
        }

        public override string GoldStar()
        {
            var data = ProcessData(_rawData);

            string goldResult = SolveGoldStar(data);

            return $"{goldResult}";
        }

        private Map ProcessData(IEnumerable<string> rawData)
        {
            return new Map(rawData.ToArray());
        }

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
            int collisions = 0;
            int xPos = 0;

            for (int yPos = down; yPos < _instance.Length; yPos += down)
            {
                xPos += right;

                int maxLength = _instance[yPos].Length;

                if (xPos >= maxLength)
                    xPos -= maxLength;

                char geography = _instance[yPos][xPos];

                if (geography == '#')
                    collisions++;
            }

            return collisions;
        }
    }

    #endregion
}
