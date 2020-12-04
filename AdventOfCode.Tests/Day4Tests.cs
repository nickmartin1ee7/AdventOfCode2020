using AdventOfCode.Library;
using AdventOfCode.Library.Day3;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day4Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day3();
        }

        [TestCase("202")]
        public void SilverStarTest(string expected)
        {
            Assert.IsTrue(_solution.SilverStar().Contains(expected));
        }

        [TestCase("151")]
        public void GoldStarTest(string expected)
        {
            Assert.IsTrue(_solution.GoldStar().Contains(expected));
        }
    }
}