using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Console
{
    public class Day1 : BaseSolution
    {

        public override string SilverStar()
        {
            var rawData = File.ReadLines($"{GetType().Name}\\data.txt");

            var data = ProcessData(rawData);

            var silverResult = SolveSilverStar(data, 2020);

            return $"{silverResult}";
        }

        public override string GoldStar()
        {
            var rawData = File.ReadLines($"{GetType().Name}\\data.txt");

            var data = ProcessData(rawData);

            var goldResult = SolveGoldStar(data, 2020);

            return $"{goldResult}";
        }

        private List<int> ProcessData(IEnumerable<string> rawData)
        {
            var numbers = new List<int>();

            foreach (var line in rawData)
                numbers.Add(int.Parse(line));

            return numbers;
        }

        private int SolveSilverStar(List<int> data, int sum)
        {
            foreach (var x in data)
            {
                foreach (var y in data)
                {
                        if (x + y == sum)
                            return x * y;
                }
            }

            return -1;
        }

        private int SolveGoldStar(List<int> data, int sum)
        {
            foreach (var x in data)
            {
                foreach (var y in data)
                {
                    foreach (var z in data)
                    {
                        if (x + y + z == sum)
                            return x * y * z;
                    }
                }
            }

            return -1;
        }
    }
}
