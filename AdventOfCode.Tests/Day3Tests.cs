using AdventOfCode.Library;
using AdventOfCode.Library.Day3;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day3Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day3();
        }

        [TestCase("240")]
        public void SilverStarTest(string expected)
        {
            Assert.IsTrue(_solution.SilverStar().Contains(expected));
        }

        [TestCase("2832009600")]
        public void GoldStarTest(string expected)
        {
            Assert.IsTrue(_solution.GoldStar().Contains(expected));
        }
    }
}