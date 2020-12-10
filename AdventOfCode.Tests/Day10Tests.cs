using AdventOfCode.Library;
using AdventOfCode.Library.Day10;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day10Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day10();
        }

        [TestCase("")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }
    }
}
