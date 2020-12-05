using AdventOfCode.Library;
using AdventOfCode.Library.Day5;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day5();
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