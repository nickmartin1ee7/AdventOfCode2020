using AdventOfCode.Library;
using AdventOfCode.Library.Day2;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day2Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day2();
        }

        [TestCase("396")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("428")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }
    }
}