using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Library.Day1
{
    public class Day1 : BaseSolution
    {
        private readonly IEnumerable<string> _rawData;

        public Day1()
        {
            _rawData = File.ReadLines(Path.Combine($"{GetType().Name}", "data.txt"));
        }
        
        public override string SilverStar()
        {
            var data = ProcessData(_rawData);

            var silverResult = SolveSilverStar(data, 2020);

            return $"{silverResult}";
        }

        public override string GoldStar()
        {
            var data = ProcessData(_rawData);

            var goldResult = SolveGoldStar(data, 2020);

            return $"{goldResult}";
        }

        private static List<int> ProcessData(IEnumerable<string> rawData) =>
            rawData
                .Select(int.Parse)
                .ToList();

        private static int SolveSilverStar(IReadOnlyCollection<int> data, int sum)
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

        private static int SolveGoldStar(IReadOnlyCollection<int> data, int sum)
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
