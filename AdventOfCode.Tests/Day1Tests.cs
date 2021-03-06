using AdventOfCode.Library;
using AdventOfCode.Library.Day1;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day1Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day1();;
        }

        [TestCase("494475")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("267520550")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }
    }
}